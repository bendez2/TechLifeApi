using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class NameRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    
        [JsonIgnore]
        public List<TypeRequest> TypeRequests = new ();
    }
}
