using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebUpdated.Models
{
    public class EmployeeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Contact Number")]
        public long ContactNum { get; set; }

        [DisplayName("Department ID")]
        public int DepartmentId {  get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [DisplayName("Name")]
        public string FullName {
            get { return FirstName + " " + MiddleName + " " + LastName; }
        }
    }
}
