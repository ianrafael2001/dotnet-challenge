

using desafio.Entity;
using desafio.Models;
using desafio.Repository;

namespace desafio.Service
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly float pageLimit = 3f;

        public ProjectService(IProjectRepository projectRepository,IEmployeeRepository employeeRepository){
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public void addProject(ProjectModel model){
            
            ProjectEntity entity = new ProjectEntity(){
                id = model.id,
                name = model.name,
                creationDate = model.creationDate,
                endDate = model.endDate,
                managerId = model.managerId
            };
            _projectRepository.Add(entity);
        }

        public ProjectModel getProject(int id){
            ProjectEntity entity = _projectRepository.Get(id);
            EmployeeEntity managerEntity = _employeeRepository.Get(entity.managerId);
            ProjectModel model = new ProjectModel(){
                id = entity.id,
                name = entity.name,
                creationDate = entity.creationDate,
                endDate = entity.endDate,
                managerId = entity.managerId,
                Manager = managerEntity
            };
            return model;
        }

        public List<ProjectModel> getAllProjects(int page){
            List<ProjectEntity> entityList = _projectRepository.GetAll(page, (int)pageLimit);
            List<ProjectModel> modelList = new List<ProjectModel>();
              foreach (var entity in entityList){
                EmployeeEntity managerEntity = _employeeRepository.Get(entity.managerId);
                ProjectModel model = new ProjectModel(){
                    id = entity.id,
                    name = entity.name,
                    creationDate = entity.creationDate,
                    endDate = entity.endDate,
                    managerId = entity.managerId,
                    Manager = managerEntity
                };
                modelList.Add(model);
              }
            return modelList;
        }
        
        public int pageCount(){            
            return (int)Math.Ceiling(_projectRepository.Count()/pageLimit);
        }        

        public void updateProject(ProjectModel model){
            Console.WriteLine("entrou service");
            ProjectEntity entity = _projectRepository.Get(model.id);
            if(entity != null){
                entity.name = !string.IsNullOrEmpty(model.name)? model.name: entity.name;
                entity.creationDate = model.creationDate  != null? model.creationDate: entity.creationDate;
                entity.endDate = model.endDate != null? model.endDate: entity.endDate;
                entity.managerId = model.managerId != 0? model.managerId: entity.managerId;
                _projectRepository.Update(entity);
            }
        }

        public int deleteProject(int id){
            _projectRepository.Delete(id);
            return id;
        }

        public bool checkUniqueName(string name){
            ProjectEntity entity = _projectRepository.findByName(name);
            return entity != null? true: false;
        }
    }
}