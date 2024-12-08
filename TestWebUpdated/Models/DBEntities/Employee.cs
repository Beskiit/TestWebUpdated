using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebUpdated.Models.DBEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public long ContactNum { get; set; }

        public int DepartmentId {  get; set; }
        public Department Department { get; set; }
    }
}
