using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Request> Requests { get; set; } = new();
    }
}
