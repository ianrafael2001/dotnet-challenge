using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio.Entity
{
    public class MemberEntity
    {
        public int id { get; set; }

        
        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        [ForeignKey("Project")]
        public int projectId { get; set; }
        
        public ProjectEntity Project { get; set; }

    }
}