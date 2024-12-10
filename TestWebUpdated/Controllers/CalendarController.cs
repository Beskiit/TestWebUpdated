using Microsoft.AspNetCore.Mvc;
using TestWebUpdated.DAL;
using TestWebUpdated.Models;
using System.Globalization;
using TestWebUpdated.Models.DBEntities;

namespace TestWebUpdated.Controllers
{
    public class CalendarController : Controller
    {
        private readonly EmployeeDBContext _context;

        public CalendarController(EmployeeDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Fetch all occupied dates from the database
            var occupiedDates = _context.Schedules
                                        .Select(s => s.ScheduleDate)
                                        .ToList();

            // Pass the data to the ViewModel
            var viewModel = new CalendarViewModel
            {
                OccupiedDate = occupiedDates
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddDate([FromBody] CalendarViewModel calendarData)
        {
            if (ModelState.IsValid)
            {
                // Save the new schedule to the database
                var newSchedule = new Schedule
                {
                    AppointmentName = calendarData.AppointmentName,
                    ScheduleDate = calendarData.ScheduleDate.Date
                };

                _context.Add(newSchedule);
                _context.SaveChanges();

                // Return updated occupied dates in the correct format (YYYY-MM-DD)
                var occupiedDates = _context.Schedules.Select(s => s.ScheduleDate.ToString("yyyy-MM-dd")).ToList();

                return Json(new { occupiedDates });
            }

            return BadRequest("Invalid data");
        }


    }
}