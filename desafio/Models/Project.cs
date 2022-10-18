using System.ComponentModel.DataAnnotations;
using desafio.Entity;

namespace desafio.Models
{
    public class ProjectModel
    {
        public int id { get; set; }
        
        public string name { get; set; }

        [DataType(DataType.Date)]
        public DateTime creationDate { get; set; }
        
        [DataType(DataType.Date)]        
        public DateTime? endDate { get; set; }

        public int managerId { get; set; }
        
        public EmployeeEntity? Manager { get; set; }
    }
}