using desafio.Context;
using desafio.Entity;

namespace desafio.Repository
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly EFContext _dataContext;

        public ProjectRepository(EFContext dataContext){
            _dataContext = dataContext;
        }

        public void Add(ProjectEntity entity) {
            _dataContext.Projects.Add(entity);
            _dataContext.SaveChanges();
        }
        public IEnumerable<ProjectEntity> Get()
        {
            return _dataContext.Projects.ToList();
        }
        public ProjectEntity Get(int id)
        {
            return _dataContext.Projects.FirstOrDefault(x => x.id == id);
        }

        public List<ProjectEntity> GetAll(int page, int pageLimit)
        {            
            return _dataContext.Projects.Skip((page - 1) * pageLimit).Take(pageLimit).ToList();;
        }

        public int Count() {
            return _dataContext.Projects.Count();
        }

        public ProjectEntity findByName(string name){
            return _dataContext.Projects.FirstOrDefault(x => x.name == name);
        }
        public void Delete(int id)
        {
            ProjectEntity entity = Get(id);
            _dataContext.Projects.Remove(entity);            
            _dataContext.SaveChanges();
        }

        public void Update(ProjectEntity entity) {
            _dataContext.Projects.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}