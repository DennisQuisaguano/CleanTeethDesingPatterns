using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System.Collections;


namespace CleanTeeth.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set;  }
    public Guid PatientId {  get; private set; }
    public Guid DentisId {  get; private set; }
    public Guid DentalOfficeId { get; private set; }
    //public string Status { get; private set; } = null!;
    public AppointmentStatusEnum Status { get; private set; } 
   // public DateTime StartDate {  get; private set; }
    //public DateTime EndDate {  get; private set; }

    public TimeInterval TimeInterval { get; private set; }

    //Campos para facilitar la navegacion entre entidades

    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    public Appointment(Guid patientId, Guid dentisId, Guid dentalOfficeId, TimeInterval timeInterval)
    {

        if (TimeInterval.Start > DateTime.UtcNow)
        {
            throw new BusinessRuleException("La fechade inicio no puede ser posterior a la fecha actual");
        }

        PatientId = patientId;
        DentisId = dentisId;
        DentalOfficeId = dentalOfficeId;
        Status = AppointmentStatusEnum.Scheduled;
        TimeInterval = timeInterval;
        Id = Guid.CreateVersion7();
    }

    public void Cancel()
    {
        if (Status != AppointmentStatusEnum.Scheduled) 
        {
            throw new BusinessRuleException("Solo se puede cancelar una cita que esta programada");
        }

        Status = AppointmentStatusEnum.Cancelled;
    }

    public void Completed()
    {
        if (Status != AppointmentStatusEnum.Scheduled)
        {
            throw new BusinessRuleException("Solo se puede completar una cita no programada");
        }

        Status = AppointmentStatusEnum.Completed;
    }
}
