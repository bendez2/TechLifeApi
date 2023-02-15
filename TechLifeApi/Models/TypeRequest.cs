using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class TypeRequest
    {
        public int Id { get; set; }

        public int NameRequestId { get; set; }

        public NameRequest NameRequest { get; set; }

        public int PriorityID { get; set; }

        public Priority? Priority { get; set; }

        public int SlaDay { get; set; }

        public int SlaHours { get; set; }

        [JsonIgnore]
        public List<Request> Requests { get; set; } = new();
    }
}
