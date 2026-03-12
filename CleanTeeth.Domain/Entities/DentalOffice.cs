using CleanTeeth.Domain.Exceptions;
using System.Timers;

namespace CleanTeeth.Domain.Entities;
public class DentalOffice
{
    //Propiedades automaticas

    #region Getters and Setters
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    #endregion

    public DentalOffice(string name)
    {
        if (string.IsNullOrEmpty(name)) {
            throw new BusinessRuleException($"El {nameof(name)}nombre del consultorio dental no puede ser nulo o vacío.");

        }
        Name = name;
        //Id id = Guid.NewGuid();
        Id = Guid.CreateVersion7();
    }


}
