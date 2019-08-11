using System.Collections.Generic;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IRepository
    {
        IEnumerable<IPatient> GetAllPatients();
        IEnumerable<IAppointmentType> GetAllAppointmentTypes();
        IAppointmentType GetAppointmentTypeById(int id);
        IEnumerable<IAppointment> GetAllAppointments();
        IPatient GetPatientById(int patiendId);
        IEnumerable<IAppointment> GetAppointmentsByPatientId(int patiendId);
        bool AddPatient(IPatient patient);
        bool AddAppointmentType(IAppointmentType appointmentType);
        bool AddAppointment(IAppointment appointment);
        bool CancelAppointment(IAppointment appointment);
    }
}
