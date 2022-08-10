using Core.Entities;

namespace API.DTOs.Center
{
    public class CenterDto
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<string> Center_Phones { get; set; }
        public List<string> Center_Specialities { get; set; }
        public List<string> Center_Insurances { get; set; }
        public List<String> Center_Doctors { get; set; }

        //public List<DateTime> Center_WeekDays { get; set; }

    }
}
