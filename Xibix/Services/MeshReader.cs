using Newtonsoft.Json;
using Xibix.Services.Models;

namespace Xibix.Services
{
    public class MeshReader
    {
        public static Mesh? GetMesh(string path = @"D:\Bewerbungen\Xibix\Xibix\Xibix\Ressources\mesh_test.json") 
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Mesh>(json);
        }
    }
}
