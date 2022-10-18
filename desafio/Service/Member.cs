

using desafio.Entity;
using desafio.Models;
using desafio.Repository;

namespace desafio.Service
{
    public class MemberService: IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly float pageLimit = 3f;

        public MemberService(IMemberRepository memberRepository,IProjectRepository projectRepository,IEmployeeRepository employeeRepository){
            _memberRepository = memberRepository;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public void addMember(MemberModel model){
            MemberEntity entity = new MemberEntity(){
                id = model.id,
                projectId = model.projectId,                
                employeeId = model.employeeId,
            };
            _memberRepository.Add(entity);
        }

        public MemberModel getMember(int id){
            MemberEntity entity = _memberRepository.Get(id);
            ProjectEntity projectEntity = _projectRepository.Get(entity.projectId);
            EmployeeEntity memberEntity = _employeeRepository.Get(entity.employeeId);
            MemberModel model = new MemberModel(){
                id = entity.id,
                projectId = entity.projectId,
                employeeId = entity.employeeId,
                Project = projectEntity,
                Employee = memberEntity,
            };
            return model;
        }

        public int deleteMember(int id){
            _memberRepository.Delete(id);
            return id;
        }

        public List<MemberModel> getAllMembers(int page) {
            List<MemberEntity> entityList = _memberRepository.GetAll(page, (int)pageLimit);
            List<MemberModel> modelList = new List<MemberModel>();
              foreach (var entity in entityList){
                
                ProjectEntity projectEntity = _projectRepository.Get(entity.projectId);
                EmployeeEntity memberEntity = _employeeRepository.Get(entity.employeeId);
                MemberModel model = new MemberModel() {
                    id = entity.id,
                    projectId = entity.projectId,
                    employeeId = entity.employeeId,
                    Project = projectEntity,
                    Employee = memberEntity,
                };
                modelList.Add(model);
            };
            return modelList;
        }
        public int pageCount(){            
            return (int)Math.Ceiling(_memberRepository.Count()/pageLimit);
        }
    }

}