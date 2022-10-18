
using desafio.Models;
using desafio.Service;
using FluentValidation;

namespace desafio.Validator
{
    public class EmployeeValidator: AbstractValidator<EmployeeModel>
    {
          public EmployeeValidator(){

                RuleFor(employee => employee.address).EmailAddress().WithMessage("Formato invalido para endereço de email");
                RuleFor(employee => employee.firstName).NotNull().WithMessage("Campo de nome obrigatorio");           
            }

    }
}