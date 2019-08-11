using System.Collections.Generic;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IRepository
    {
        List<Patient> GetAllPatients();
        List<AppointmentType> GetAllAppointmentTypes();
        IAppointmentType GetAppointmentTypeById(int id);
        List<Appointment> GetAllAppointments();
        IPatient GetPatientById(int patiendId);
        List<Appointment> GetAppointmentsByPatientId(int patiendId);
        bool AddPatient(IPatient patient);
        bool AddAppointmentType(IAppointmentType appointmentType);
        bool AddAppointment(IAppointment appointment);
        bool CancelAppointment(IAppointment appointment);
    }
}
