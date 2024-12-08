using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebUpdated.DAL;
using TestWebUpdated.Models;
using TestWebUpdated.Models.DBEntities;

namespace TestWebUpdated.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController1(EmployeeDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
			List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
			var employees = _context.Employees.Include(x => x.Department).ToList();

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        id = employee.id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        MiddleName = employee.MiddleName,
                        ContactNum = employee.ContactNum,
                        DepartmentName = employee.Department.DepartmentName
                    };
                    employeeList.Add(EmployeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Map EmployeeViewModel to your Employee entity
                    var employee = new Employee
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        MiddleName = employeeData.MiddleName,
                        ContactNum = employeeData.ContactNum,
                        DepartmentId = employeeData.DepartmentId
                    };

                    // Add the employee to the database
                    _context.Employees.Add(employee);
                    _context.SaveChanges();

                    TempData["successMessage"] = " Employee created successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = " Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
