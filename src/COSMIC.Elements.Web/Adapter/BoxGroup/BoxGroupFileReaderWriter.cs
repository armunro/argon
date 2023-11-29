using System.Collections.Generic;
using System.IO;
using COSMIC.Elements.Web.Domain.Config;
using COSMIC.Elements.Web.Domain.Screen;
using Newtonsoft.Json;


namespace COSMIC.Elements.Web.Adapter.BoxGroup
{
    public class BoxGroupFileReaderWriter : IBoxGroupReader, IBoxGroupWriter
    {
        private string _filePath;

        public BoxGroupFileReaderWriter(string filePath)
        {
            _filePath = filePath;
        }

        public Dictionary<string, ScreenGroup> ReadToolsets()
        {
            
            Dictionary<string, ScreenGroup> toolSets = new Dictionary<string, ScreenGroup>();

            string[] toolDirectories = Directory.GetDirectories(_filePath);
            foreach (string toolDirectoryPath in toolDirectories)
            {
                string toolName = Path.GetFileName(toolDirectoryPath);
                ScreenGroup newScreenGroup = new ScreenGroup();

                string[] toolFiles = Directory.GetFiles( toolDirectoryPath, "*.tool.json");
                foreach (string toolFile in toolFiles)
                {
                    ScreenModel newScreenModel = JsonConvert.DeserializeObject<ScreenModel>(System.IO.File.ReadAllText(toolFile));
                    newScreenGroup.Tools.Add(newScreenModel);
                }

                newScreenGroup.Name = toolName;
                toolSets[toolName] = newScreenGroup;
            }

            return toolSets;
        }

        public void WriteToolset(ScreenGroup toolset)
        {
            
            string configDirectoryPath = Path.Join(_filePath, toolset.Name);
            if (!Directory.Exists(configDirectoryPath))
            {
                Directory.CreateDirectory(configDirectoryPath);
            }

            foreach (ScreenModel tool in toolset.Tools)
            {
                string toolPath = Path.Join(_filePath, toolset.Name, $"{tool.Name}.tool.json");
                System.IO.File.WriteAllText(toolPath, JsonConvert.SerializeObject(tool, Formatting.Indented));
            }
        }
    }
}