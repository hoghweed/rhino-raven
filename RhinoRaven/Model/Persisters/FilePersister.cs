using System;
using System.IO;
using Newtonsoft.Json;
using Rhino.Commands;

namespace RhinoRaven.Model.Persisters
{
    public class FilePersister : IPersister
    {
        public OperationResult Store(SelectionSnapshot snapshot)
        {
            try
            {
                var result = JsonConvert.SerializeObject(
                    snapshot,
                    new JsonSerializerSettings() {
                        Formatting = Formatting.Indented,
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

                var destinationPath = Path.Combine(RhinoRavenPathProvider.ExecutingPluginPath, "selections", snapshot.SourceName.Replace(' ', '-').Replace('.','-'));
                if (!Directory.Exists(destinationPath))
                    Directory.CreateDirectory(destinationPath);

                var destinationFile = Path.Combine(destinationPath, string.Concat(snapshot.Id, ".json"));
                File.WriteAllText(destinationFile, result, System.Text.Encoding.UTF8);
                return OperationResult.AsSuccess(destinationFile);
            }
            catch (Exception ex)
            {
                return OperationResult.AsError(ex);
            }
        }
    }
}