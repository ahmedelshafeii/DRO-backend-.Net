namespace API.DTOs
{
    public class ReviewDto
    {
        public string ReviewString { get; set; }
        public int? Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string PatientId { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; }
    }
}
