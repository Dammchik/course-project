using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApplication.Models
{
    public class Recording
    {
        public int RecordingId { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime Time { get; set; }
            
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you`ll attend")]
        public bool? WillAttend { get; set; }
        // Дополнительные свойства
    }
}
