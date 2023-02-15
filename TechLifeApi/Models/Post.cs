using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class Post
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; } = new();
    }
}
