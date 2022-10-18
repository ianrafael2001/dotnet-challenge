
using desafio.Models;

namespace desafio.Service
{
    public interface IEmployeeService
    {
        public void addEmployee(EmployeeModel model);

        public EmployeeModel getEmployee(int id);
        
        public void updateEmployee(EmployeeModel model);

        public int deleteEmployee(int id);

       public List<EmployeeModel> getAllEmployees(int page);
       public int pageCount();
    }

        public interface IMemberService
    {
        public void addMember(MemberModel model);

        public MemberModel getMember(int id);

        public int deleteMember(int id);

       public List<MemberModel> getAllMembers(int page);
       public int pageCount();
    }

        public interface IProjectService
    {
        public void addProject(ProjectModel model);

        public ProjectModel getProject(int id);

        public List<ProjectModel> getAllProjects(int page);
        
        public void updateProject(ProjectModel model);

        public int deleteProject(int id);
        public bool checkUniqueName(string name);
         public int pageCount();
        
    }
}