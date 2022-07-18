using System.Collections.Generic;
using FluentValidation;
using Formula1.Domain.Types;

namespace Formula1.MVC.Models.Validators
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, TElement> IsEmail<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must(x => TypesValidation.IsValidEmail(x?.ToString()));
        }
    }
}