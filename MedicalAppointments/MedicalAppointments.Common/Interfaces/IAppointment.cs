using System;

namespace MedicalAppointments.Common.Interfaces
{
    public interface IAppointment
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        bool IsActive { get; set; }
        int PatientId { get; set; }
        int AppointmentTypeId { get; set; }
    }
}
