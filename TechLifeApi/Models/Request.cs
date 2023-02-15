namespace TechLifeApi.Models
{
    public class Request
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public int TypeId { get; set; }
        public TypeRequest? Type { get; set; }

        public string Text { get; set; }

        public string Location { get; set; }

        public DateTime ExucationTime { get; set; }

        public int StatusId { get; set; }
        public Status? Status { get; set; }

        public DateTime ChangeTime { get; set; }

        public string Comment { get; set; }

        public DateTime? CloseTime { get; set; }

        public int InitiatorId { get; set; }
        public Initiator? Initiator { get; set; }


        public string HistoryExecutor { get; set; }

        public DateTime? StartDateTime { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
}
