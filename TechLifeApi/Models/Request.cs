using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechLifeApi.Models
{
    public class Request
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        [JsonIgnore]
        public int TypeId { get; set; }
        [JsonIgnore]
        public TypeRequest? Type { get; set; }
        [NotMapped]
        public string TypeName
        {
            get
            {
                return Type.Name;
            }
            set
            {

            }
        }

        public string Text { get; set; }

        public string Location { get; set; }

        public string Priority { get; set; }

        public DateTime ExucationTime { get; set; }

        [JsonIgnore]
        public int StatusId { get; set; }
        [JsonIgnore]
        public Status? Status { get; set; }
        [NotMapped]
        public string StatusName
        {
            get
            {
                return Status.Name;
            }
            set
            {

            }
        }

        public DateTime ChangeTime { get; set; }

        public string Comment { get; set; }

        public DateTime CloseTime { get; set; }

        [JsonIgnore]
        public int InitiatorId { get; set; }
        [JsonIgnore]
        public Initiator? Initiator { get; set; }
        [NotMapped]
        public string InitiatorName
        {
            get
            {
                return Initiator.Name;
            }
            set
            {

            }
        }



    }
}
