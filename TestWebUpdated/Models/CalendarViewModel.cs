namespace TestWebUpdated.Models
{
    public class CalendarViewModel
    {
        public List<DateTime> OccupiedDate { get; set; }
        public string AppointmentName { get; set; } // Add this property
        public DateTime ScheduleDate { get; set; }  // Add this property
    }
}
