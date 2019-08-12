using System;

namespace MedicalAppointments.Common.Interfaces
{
    public interface IAppointment : IModel
    {
        DateTime Date { get; set; }
        bool IsActive { get; set; }
        int PatientId { get; set; }
        int AppointmentTypeId { get; set; }
    }
}
