using System.Collections.Generic;
using System.IO;
using Boxd.Service.Domain.Box;
using Boxd.Service.Domain.Config;
using Newtonsoft.Json;


namespace Boxd.Service.Adapter.BoxGroup
{
    public class BoxGroupFileReaderWriter : IBoxGroupReader, IBoxGroupWriter
    {
        private string _filePath;

        public BoxGroupFileReaderWriter(string filePath)
        {
            _filePath = filePath;
        }

        public Dictionary<string, Domain.Box.BoxGroup> ReadToolsets()
        {
            
            Dictionary<string, Domain.Box.BoxGroup> toolSets = new Dictionary<string, Domain.Box.BoxGroup>();

            string[] toolDirectories = Directory.GetDirectories(_filePath);
            foreach (string toolDirectoryPath in toolDirectories)
            {
                string toolName = Path.GetFileName(toolDirectoryPath);
                Domain.Box.BoxGroup newBoxGroup = new Domain.Box.BoxGroup();

                string[] toolFiles = Directory.GetFiles( toolDirectoryPath, "*.tool.json");
                foreach (string toolFile in toolFiles)
                {
                    Box newBox = JsonConvert.DeserializeObject<Box>(System.IO.File.ReadAllText(toolFile));
                    newBoxGroup.Tools.Add(newBox);
                }

                newBoxGroup.Name = toolName;
                toolSets[toolName] = newBoxGroup;
            }

            return toolSets;
        }

        public void WriteToolset(Domain.Box.BoxGroup toolset)
        {
            
            string configDirectoryPath = Path.Join(_filePath, toolset.Name);
            if (!Directory.Exists(configDirectoryPath))
            {
                Directory.CreateDirectory(configDirectoryPath);
            }

            foreach (Box tool in toolset.Tools)
            {
                string toolPath = Path.Join(_filePath, toolset.Name, $"{tool.Name}.tool.json");
                System.IO.File.WriteAllText(toolPath, JsonConvert.SerializeObject(tool, Formatting.Indented));
            }
        }
    }
}