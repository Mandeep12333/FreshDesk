using System;
using System.Collections.Generic;

namespace FreshDesk.Models
{
    public class NotesModel
    {
        public string body { get; set; }
        public string body_text { get; set; }
        public object id { get; set; }
        public bool incoming { get; set; }
        public bool Private { get; set; }
        public object user_id { get; set; }
        public string support_email { get; set; }
        public int source { get; set; }
        public int category { get; set; }
        public int ticket_id { get; set; }
        public IList<string> to_emails { get; set; }
        public string from_email { get; set; }
        public IList<object> cc_emails { get; set; }
        public IList<object> bcc_emails { get; set; }
        public int? email_failure_count { get; set; }
        public object outgoing_failures { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public IList<object> attachments { get; set; }
        public object source_additional_info { get; set; }
    }
}
