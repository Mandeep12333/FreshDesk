namespace FreshDesk.Models
{
    public class NoteModel
    {
        public string body { get; set; }
        public string[] notify_emails { get; set; }
        public bool Private { get; set; } = true;
    }
}
