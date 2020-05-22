using FreshDesk.Enum;
using System.ComponentModel.DataAnnotations;

namespace FreshDesk.Models
{
    public class TicketModel
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Email must be in joe@aol.com this format")]
        public string email { get; set; }
        [Required(ErrorMessage = "Subject is Required")]
        public string subject { get; set; }
        [Required]
        [Range(2,5, ErrorMessage = "Status are in between 2 to 5.")]
        public TicketStatus status { get; set; }
        [Required]
        [Range(1,4, ErrorMessage = "Priority in between 1 to 4")]
        public TicketPriority priority { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string description { get; set; }
    }
}
