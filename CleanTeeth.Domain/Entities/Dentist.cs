using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Dentist
{

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Dentist(string name, string email) 
    {
        //Refactorizar el nombre para dentist y patient
        if(string.IsNullOrWhiteSpace(name))
            throw new BusinessRuleException($"El {nameof(name)} es obligatorio");
        Name = name;
        Id = Guid.CreateVersion7();
    }

}
