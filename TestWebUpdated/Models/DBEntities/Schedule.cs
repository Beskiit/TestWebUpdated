using System.ComponentModel.DataAnnotations;

namespace TestWebUpdated.Models.DBEntities
{
    public class Schedule
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string AppointmentName { get; set; }

        [Required]
        public DateTime ScheduleDate { get; set; }
    }
}