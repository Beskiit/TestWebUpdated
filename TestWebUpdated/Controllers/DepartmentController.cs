using Microsoft.AspNetCore.Mvc;
using TestWebUpdated.DAL;
using TestWebUpdated.Models;
using TestWebUpdated.Models.DBEntities;

namespace TestWebUpdated.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly EmployeeDBContext _context;

		public DepartmentController(EmployeeDBContext context) 
		{ 
			_context = context;
		}

        [HttpPost]
        public IActionResult Add(DepartmentViewModel departmentData)
        {

			try
			{
				if (ModelState.IsValid)
				{
					var department = new Department
					{
						DepartmentId = departmentData.DepartmentId,
						DepartmentName = departmentData.DepartmentName,
						DepartmentDescription = departmentData.DepartmentDescription
					};

					_context.Departments.Add(department);
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

		public IActionResult Index()
		{
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>();
            var departments = _context.Departments.ToList();

            if (departments != null)
            {
                foreach (var department in departments)
                {
                    var DepartmentViewModel = new DepartmentViewModel()
                    {
                        DepartmentId = department.DepartmentId,
						DepartmentName = department.DepartmentName,
						DepartmentDescription = department.DepartmentDescription
                    };
                    departmentList.Add(DepartmentViewModel);
                }
                return View(departmentList);
            }
            return View(departmentList);
        }
	}
}
