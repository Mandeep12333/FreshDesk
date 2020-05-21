using System;
using System.Collections.Generic;

namespace FreshDesk.Models
{
    public class TicketsModel
    {
        public IList<object> cc_emails { get; set; }
        public IList<object> fwd_emails { get; set; }
        public IList<object> reply_cc_emails { get; set; }
        public IList<object> ticket_cc_emails { get; set; }
        public bool fr_escalated { get; set; }
        public bool spam { get; set; }
        public object email_config_id { get; set; }
        public long? group_id { get; set; }
        public int priority { get; set; }
        public object requester_id { get; set; }
        public long? responder_id { get; set; }
        public int source { get; set; }
        public object company_id { get; set; }
        public int status { get; set; }
        public string subject { get; set; }
        public object association_type { get; set; }
        public object to_emails { get; set; }
        public object product_id { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public DateTime due_by { get; set; }
        public DateTime fr_due_by { get; set; }
        public bool is_escalated { get; set; }
        public CustomFields custom_fields { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object associated_tickets_count { get; set; }
        public IList<string> tags { get; set; }
        public object nr_due_by { get; set; }
        public bool nr_escalated { get; set; }
        public class CustomFields
        {
        }
    }
}
