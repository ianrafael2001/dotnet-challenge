using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio.Entity
{
    public class ProjectEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        [DataType(DataType.Date)]
        public DateTime creationDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? endDate { get; set; }

        [ForeignKey("Employee")]
        public int managerId { get; set; }
        
        public EmployeeEntity Manager { get; set; }
    }
}