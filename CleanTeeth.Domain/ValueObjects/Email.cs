
using CleanTeeth.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace CleanTeeth.Domain.ValueObjects;

public class Email
{
    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public string Value { get; } = null!;

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }

        if (!EmailRegex.IsMatch(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es valido");
        }

        Value = email;
    }
}