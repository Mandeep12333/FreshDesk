using System.ComponentModel.DataAnnotations;

namespace FreshDesk.Models
{
    public class NoteModel
    {
        [Required(ErrorMessage = "body is Required")]
        public string body { get; set; }
    }
}
