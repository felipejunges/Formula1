using FluentValidation;

namespace Formula1.MVC.Models.Validators
{
    public class CadastroViewModelValidator : AbstractValidator<CadastroViewModel>
    {
        public CadastroViewModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(x => x.Nome).MaximumLength(255).WithMessage("O tamanho máximo do nome é de 255 caracteres");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O e-mail é obrigatório");
            RuleFor(x => x.Email).IsEmail().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("O e-mail deve ser informado corretamente");
            RuleFor(x => x.ConfirmacaoEmail).Equal(x => x.Email).When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("O e-mail não confere");

            RuleFor(x => x.Senha).NotEmpty().WithMessage("A senha é obrigatória");
            RuleFor(x => x.ConfirmacaoSenha).Equal(x => x.Senha).When(x => !string.IsNullOrEmpty(x.Senha)).WithMessage("A senha não confere");
        }
    }
}