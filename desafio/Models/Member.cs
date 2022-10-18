using System.ComponentModel.DataAnnotations;
using desafio.Entity;

namespace desafio.Models
{
    public class MemberModel
    {
        
        public int id { get; set; }

        public int employeeId { get; set; }

        public int projectId { get; set; }
        public EmployeeEntity? Employee { get; set; }

        public ProjectEntity? Project { get; set; }

    }
}