namespace BarbershopWebApplication.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime Time { get; set; }
        // Дополнительные свойства
    }
}
