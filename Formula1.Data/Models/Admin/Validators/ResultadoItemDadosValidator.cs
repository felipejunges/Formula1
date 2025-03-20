using FluentValidation;
using Formula1.Data.Models.Admin.Resultados;

namespace Formula1.Data.Models.Admin.Validators
{
    public class ResultadoItemDadosValidator : AbstractValidator<ResultadoItemDados>
    {
        public ResultadoItemDadosValidator()
        {
            When(o => o.PilotoId.HasValue, () =>
            {
                RuleFor(o => o.EquipeId).NotEmpty().WithMessage("A equipe é obrigatória.");
            });

            When(o => !o.PilotoId.HasValue, () =>
            {
                RuleFor(o => o.EquipeId).Empty().WithMessage("A equipe é não deve ser informada.");
            });
        }
    }
}