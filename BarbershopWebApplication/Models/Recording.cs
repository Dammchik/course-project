using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApplication.Models
{
    public class Recording
    {
        public int RecordingId { get; set; }
        
        public int BarberId { get; set; }
        
        public Barber? Barber { get; set; }
        public int ServiceId { get; set; }
        
        public Service? Service { get; set; }
        public DateTime Time { get; set; }
            
        [Required(ErrorMessage = "Пожалуйста введите своё имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите свой e-mail")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Пожалуйста введите корректный email")]
        public string Email { get; set; }  
        [Required(ErrorMessage = "Пожалуйста введите свой номер телефона")]
        //[RegularExpression("^((\\+7|7|8)+([0 - 9]){10})$",
        //    ErrorMessage = "Пожалуйста введите корректный номер")]
        public string Phone { get; set; }
        
    }
}
