using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebUpdated.Models
{
	public class DepartmentViewModel
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId {  get; set; }

		[DisplayName("Department Name")]
		public string DepartmentName {  get; set; }

		[DisplayName("Department Description")]
		public string DepartmentDescription {  get; set; }
	}
}
