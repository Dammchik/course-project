namespace BarbershopWebApplication.Models
{
    public class Repository
    {
        private static List<Recording> _records = new List<Recording>();
        public static IEnumerable<Recording> Recordings { get { return _records; } }
        
        public static void AddRecordings(Recording recordings)
        {
            _records.Add(recordings);   
        }
    }
}
