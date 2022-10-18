using desafio.Context;
using desafio.Entity;

namespace desafio.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EFContext _dataContext;

        public EmployeeRepository(EFContext dataContext){
            _dataContext = dataContext;
        }

        public void Add(EmployeeEntity entity) {
            _dataContext.Employees.Add(entity);
            _dataContext.SaveChanges();
        }
        public IEnumerable<EmployeeEntity> Get()
        {
            return _dataContext.Employees.ToList();
        }
        public EmployeeEntity Get(int id)
        {
            return _dataContext.Employees.FirstOrDefault(x => x.id == id);
        }

        public List<EmployeeEntity> GetAll(int page, int pageLimit)
        {
            return _dataContext.Employees.Skip((page - 1) * pageLimit).Take(pageLimit).ToList();
        }

        public void Delete(int id)
        {
            EmployeeEntity entity = Get(id);
            _dataContext.Employees.Remove(entity);            
            _dataContext.SaveChanges();
        }

        public void Update(EmployeeEntity entity) {
            _dataContext.Employees.Update(entity);
            _dataContext.SaveChanges();
        }
        public int Count() {
            return _dataContext.Employees.Count();
        }
        
    }
}