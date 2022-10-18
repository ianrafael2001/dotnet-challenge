using desafio.Entity;

namespace desafio.Repository
{
    public interface IProjectRepository
    {
        public void Add(ProjectEntity entity);
        public ProjectEntity Get(int id);
        public void Update(ProjectEntity entity);       
        public void Delete(int id);
        public List<ProjectEntity> GetAll(int page, int pageLimit);
         public ProjectEntity findByName(string name);
         public int Count();
    }

        public interface IEmployeeRepository
    {
        public void Add(EmployeeEntity entity);
        public EmployeeEntity Get(int id);
        public void Update(EmployeeEntity entity);       
        public void Delete(int id);
             
        public List<EmployeeEntity> GetAll(int page, int pageLimit);
        public int Count();
    }

    public interface IMemberRepository
    {
        public void Add(MemberEntity entity);
        public MemberEntity Get(int id);
        public void Delete(int id);
        public List<MemberEntity> GetAll(int page, int pageLimit);
         public int Count();
    }
}