namespace API.DTOs.Clinic
{
    public class ClinicDto
    {
        public string clinicName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double FEE { get; set; }
        public Guid DocId { get; set; }
    }
}
