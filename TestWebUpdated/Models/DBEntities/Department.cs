using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestWebUpdated.Models.DBEntities
{
	public class Department
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DepartmentId { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string DepartmentName { get; set; }

		public string DepartmentDescription { get; set; }

		public List<Employee> Employees { get; set; }
	}
}
