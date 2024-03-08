namespace BarbershopWebApplication.Models
{
    public class Repository
    {
        private static List<BarbershopRecordings> _records = new List<BarbershopRecordings>();
        public static IEnumerable<BarbershopRecordings> Recordings { get { return _records; } }
        
        public static void AddRecordings(BarbershopRecordings recordings)
        {
            _records.Add(recordings);   
        }
    }
}
