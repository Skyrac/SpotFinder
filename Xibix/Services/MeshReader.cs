using Newtonsoft.Json;
using Xibix.Services.Models;

namespace Xibix.Services
{
    public class MeshReader
    {
        public static Mesh? GetMesh(string path = @"D:\Bewerbungen\Xibix\Xibix\Xibix\Ressources\mesh20000.json") 
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Mesh>(json);
        }
    }
}
