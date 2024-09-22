using FluentValidation;
using System.Text.RegularExpressions;

namespace TodoApp.Application.Models;

public static partial class TodoAppValidations
{
    #region [ TodoId ]

    public const int TodoIdMinLength = 1;
    public const int TodoIdMaxLength = 1;

    [GeneratedRegex(@"^\S+$")]
    public static partial Regex GetTodoIdRegex();


    public static IRuleBuilderOptions<T, string> IsValidTodoId<T>(
        this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Cascade(CascadeMode.Stop)
            .TodoIdRules();
    }

    public static IRuleBuilderOptions<T, string> TodoIdRules<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .Length(TodoIdMinLength, TodoIdMaxLength)
            .Matches(GetTodoIdRegex());
    }

    #endregion [ TodoId ]
}
