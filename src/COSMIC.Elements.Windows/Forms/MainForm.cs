using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using COSMIC.Elements.Web;
using COSMIC.Elements.Web.Adapter;
using COSMIC.Elements.Web.Domain.Config;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost;

namespace COSMIC.Elements.Windows.Forms
{
    public partial class MainForm : Form, IScreenHostController
    {
        public static IContainer Container;
        public static ElementsAspCorePresentation Presentation = new();

        public Dictionary<string, ScreenGroup> ScreenGroups { get; set; }

        public Dictionary<Guid, ScreenInstance> Instances { get; set; } = new();

        public MainForm(string configDir)
        {
            string toolsetDir = Path.Join(configDir, "toolsets");
            var builder = new ContainerBuilder();
           
            builder.RegisterInstance(this).As<IScreenHostController>();
            builder.RegisterType<ScreenGroupFileReaderWriter>().As<IScreenGroupReader>().SingleInstance()
                .WithParameter(new NamedParameter("filePath", toolsetDir));
            builder.RegisterType<ScreenGroupFileReaderWriter>().As<IScreenGroupWriter>().SingleInstance()
                .WithParameter(new NamedParameter("filePath", toolsetDir));
            Container = builder.Build();
            ScreenGroups = Container.Resolve<IScreenGroupReader>().ReadToolsets();
            Presentation.Start(Container);


            InitializeComponent();
            NotifyIcon.Icon = new System.Drawing.Icon("icon.ico");
            NotifyIcon.Visible = true;
        }

        public IScreenHost CreateScreenHost(ScreenModel screenModel, Guid instanceId)
        {
            IScreenHost screenHost= new BrowserScreenHost();
            screenHost.InstanceId = instanceId;
            screenHost.SetHostBox(screenModel);
            return screenHost;
        }

        public void OpenScreen(string groupName, string screenName)
        {
            ScreenModel screenModel = ScreenGroups[groupName].Tools.FirstOrDefault(x => x.Name == screenName);
            Guid newInstanceId = Guid.NewGuid();


            Invoke(new Action(() =>
            {
                IScreenHost host = CreateScreenHost(screenModel, newInstanceId);

                ScreenInstance newInstance = new ScreenInstance(screenModel: screenModel, host: host, instanceId: newInstanceId);
                Instances[newInstance.InstanceId] = newInstance;
                newInstance.Host.InstanceId = newInstanceId;
                newInstance.Host.OpenWindow();
            }));
        }

        public void CloseScreen(string groupName, string screenName)
        {
            Invoke(new Action(() =>
            {
                ScreenInstance instance = Instances.Values.FirstOrDefault(x => x.ScreenModel.Name == screenName);
                instance.Host.CloseBox();
                Instances.Remove(instance.InstanceId);
            }));
        }

        public ScreenInstance GetScreenByName(string name)
        {
            var boxInstance = Instances.Values.Where(x => x.ScreenModel.Name == name).FirstOrDefault();
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