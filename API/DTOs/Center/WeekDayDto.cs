namespace API.DTOs.Center
{
    public class WeekDayDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Day { get; set; }
        public Guid CenterId { get; set; }

    }
}
