using Newtonsoft.Json;
using Xibix.Services.Models;

namespace Xibix.Services
{
    public class MeshReader
    {
        public static Mesh GetMesh(string path = @"D:\Bewerbungen\Xibix\Xibix\Xibix\Ressources\mesh20000.json") 
        {
            try
            {
                return GetMeshFromJson(File.ReadAllText(path));
            } catch(Exception ex)
            {
                return new Mesh();
            }
        }

        public static Mesh GetMeshFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Mesh>(json) ?? new Mesh();
        }
    }
}
