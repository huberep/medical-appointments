using MedicalAppointments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IRespository
    {
        IList<IPatient> GetAllPatients();
        IList<IAppointmentType> GetAllAppointmentTypes();
        IList<IAppointment> GetAllAppointments();
        IPatient GetPatientById(int patiendId);
        IList<IAppointment> GetAppointmentsByPatientId(int patiendId);
        bool AddPatient(IPatient patient);
        bool AddAppointmentType(IAppointmentType appointmentType);
        bool AddAppointment(IAppointment appointment);
    }
}
