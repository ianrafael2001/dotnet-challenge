

using desafio.Entity;
using desafio.Models;
using desafio.Repository;

namespace desafio.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly float pageLimit = 3f;

        public EmployeeService(IEmployeeRepository employeeRepository){
            _employeeRepository = employeeRepository;
        }

        public void addEmployee(EmployeeModel model){
            EmployeeEntity entity = new EmployeeEntity(){
                id = model.id,
                firstName = model.firstName,
                lastName = model.lastName,
                phone = model.phone,
                address = model.address,
            };
            _employeeRepository.Add(entity);
        }

        public EmployeeModel getEmployee(int id){
            EmployeeEntity entity = _employeeRepository.Get(id);
            EmployeeModel model = new EmployeeModel(){
                id = entity.id,
                firstName = entity.firstName,
                lastName = entity.lastName,
                phone = entity.phone,
                address = entity.address,
            };
            return model;
        }

        public void updateEmployee(EmployeeModel model){
            EmployeeEntity entity = _employeeRepository.Get(model.id);

            if(entity != null){
                entity.firstName = !string.IsNullOrEmpty(model.firstName)? model.firstName: entity.firstName;
                entity.lastName = !string.IsNullOrEmpty(model.lastName)? model.lastName: entity.lastName;
                entity.phone = !string.IsNullOrEmpty(model.phone)? model.phone: entity.phone;
                entity.address = !string.IsNullOrEmpty(model.address)? model.address: entity.address;

                _employeeRepository.Update(entity);
            }
        }

        public int deleteEmployee(int id){
            _employeeRepository.Delete(id);
            return id;
        }

        public List<EmployeeModel> getAllEmployees(int page) {
            List<EmployeeEntity> entityList = _employeeRepository.GetAll(page, (int)pageLimit);
            List<EmployeeModel> modelList = new List<EmployeeModel>();
              foreach (var entity in entityList){
                EmployeeModel model = new EmployeeModel() {
                    id = entity.id,
                    firstName = entity.firstName,
                    lastName = entity.lastName,
                    phone = entity.phone,
                    address = entity.address
                };
                modelList.Add(model);
            };
            return modelList;
        }
        public int pageCount(){            
            return (int)Math.Ceiling(_employeeRepository.Count()/pageLimit);
        }
    }

}