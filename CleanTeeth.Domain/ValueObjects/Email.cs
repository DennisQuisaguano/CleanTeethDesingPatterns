
using CleanTeeth.Domain.Exceptions;
using System.Xml.Linq;

namespace CleanTeeth.Domain.ValueObjects;

public class Email
{
    public string Value { get;} = null!;

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }

        //validar por completo el email -- expresiones regulares

        if (!email.Contains("@"))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es valido");
        }

        Value = email;

    }
}
