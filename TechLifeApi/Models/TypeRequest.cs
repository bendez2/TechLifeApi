using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class TypeRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public int PriorityID { get; set; }

        [JsonIgnore]
        public Priority? Priority { get; set; }

        [NotMapped]
        public string PriorityName { 
            get 
            {
                return Priority.Name; 
            } 
            set 
            { 
            }
        }

        public string SLA { get; set; }

        [JsonIgnore]
        public List<Request> Requests { get; set; } = new();
    }
}
