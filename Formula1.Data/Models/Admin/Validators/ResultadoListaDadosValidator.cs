using FluentValidation;
using Formula1.Data.Models.Admin.Resultados;

namespace Formula1.Data.Models.Admin.Validators
{
    public class ResultadoListaDadosValidator : AbstractValidator<ResultadoListaDados>
    {
        public ResultadoListaDadosValidator()
        {
            RuleForEach(o => o.Resultados).SetValidator(new ResultadoItemDadosValidator());
        }
    }
}