using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using COSMIC.Elements.Web;
using COSMIC.Elements.Web.Adapter.BoxGroup;
using COSMIC.Elements.Web.Domain.Box;
using COSMIC.Elements.Web.Domain.Box.Host;
using COSMIC.Elements.Web.Domain.Config;
using COSMIC.Elements.Windows.Adapter.Host.WinForms;
using FontAwesome.Sharp;

namespace COSMIC.Elements.Windows
{
    public partial class MainForm : Form, IBoxHostController
    {
        public static IContainer Container;
        public static ElementsAspCorePresentation Presentation = new();

        public Dictionary<string, BoxGroup> BoxGroups { get; set; }

        public Dictionary<Guid, BoxInstance> Instances { get; set; } = new();

        public MainForm(string configDir)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Dependencies.ToolsModule>();

            builder.RegisterInstance(this).As<IBoxHostController>();

            string toolsetDir = Path.Join(configDir, "toolsets");
            builder.RegisterType<BoxGroupFileReaderWriter>().As<IBoxGroupReader>().SingleInstance()
                .WithParameter(new NamedParameter("filePath", toolsetDir));
            builder.RegisterType<BoxGroupFileReaderWriter>().As<IBoxGroupWriter>().SingleInstance()
                .WithParameter(new NamedParameter("filePath", toolsetDir));
            Container = builder.Build();
            BoxGroups = Container.Resolve<IBoxGroupReader>().ReadToolsets();
            Presentation.Start(Container);


            InitializeComponent();
            NotifyIcon.Icon =
                System.Drawing.Icon.FromHandle(IconChar.Archive.ToBitmap(32, 32, color: Color.White).GetHicon());
            NotifyIcon.Visible = true;
        }

        public IBoxHost CreateBox(Box box, Guid instanceId)
        {
            IBoxHost boxHost;
            boxHost = new BrowserBoxHost();
            boxHost.InstanceId = instanceId;
            boxHost.SetHostBox(box);
            return boxHost;
        }

        public void StartBox(string toolsetName, string toolName)
        {
            Box box = BoxGroups[toolsetName].Tools.FirstOrDefault(x => x.Name == toolName);
            Guid newInstanceId = Guid.NewGuid();


            Invoke(new Action(() =>
            {
                IBoxHost host = CreateBox(box, newInstanceId);

                BoxInstance newInstance = new BoxInstance(box: box, host: host, instanceId: newInstanceId);
                Instances[newInstance.InstanceId] = newInstance;
                newInstance.Host.InstanceId = newInstanceId;
                newInstance.Host.OpenWindow();
            }));
        }

        public void StopBox(string toolsetName, string toolName)
        {
            Invoke(new Action(() =>
            {
                BoxInstance instance = Instances.Values.Where(x => x.Box.Name == toolName).FirstOrDefault();
                instance.Host.CloseBox();
                Instances.Remove(instance.InstanceId);
            }));
        }

        public BoxInstance GetBoxByName(string name)
        {
            var boxInstance = Instances.Values.Where(x => x.Box.Name == name).FirstOrDefault();
            return boxInstance;
        }

        # region ################ Form Events ################

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                NotifyIcon.Visible = true;
            }
        }

        private void NotifyIconOnClick(object? sender, EventArgs e)
        {
            LaunchDialog launchDialog = new LaunchDialog();

            launchDialog.ShowDialog();
        }

        # endregion
    }
}