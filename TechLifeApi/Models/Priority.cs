using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class Priority
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<TypeRequest> RequestTypes { get; set; } = new(); 
    }
}
