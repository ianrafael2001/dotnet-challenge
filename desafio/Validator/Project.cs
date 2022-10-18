
using desafio.Models;
using desafio.Service;
using FluentValidation;

namespace desafio.Validator
{
    public class ProjectValidator: AbstractValidator<ProjectModel>
    {
        readonly IProjectService _projectService;
          public ProjectValidator(IProjectService projectService)
            {
                _projectService = projectService;

                RuleFor(project => project.managerId).NotNull();
                RuleFor(project => project.managerId).NotEqual(0);
                RuleFor(project => project.name).NotNull().WithMessage("Campo de nome obrigatorio");
                RuleFor(project => project.name).Must(uniqueName).WithMessage("Nome de projeto já existente");
                RuleFor(project => project).Must(ordenedDates).WithMessage("A data de criação deve ser antes da data de encerramento");            
            }

            public bool uniqueName(string name) {
                return !_projectService.checkUniqueName(name);
            }

            public bool ordenedDates(ProjectModel project){
                if(project.endDate != null) {
                    int result = DateTime.Compare(project.creationDate, (DateTime)project.endDate );
                    if(result<=0) return true;
                }
                return false;
            }

    }
}