using FluentValidation;

namespace Progress.Application.Common
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> IsColorString<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, x, context) => {
                return x is not null && x.Length == 7 && x.First() == '#' && x.Substring(1).All("0123456789abcdefABCDEF".Contains);
            })
            .WithMessage("{PropertyName} is not acceptable color format");
        }
    }
}
