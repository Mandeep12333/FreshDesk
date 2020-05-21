namespace FreshDesk.Models
{
    public class TicketModel
    {
        public string email { get; set; }
        public string subject { get; set; }
        public long? status { get; set; }
        public long? priority { get; set; }
        public string description { get; set; }
    }
}
