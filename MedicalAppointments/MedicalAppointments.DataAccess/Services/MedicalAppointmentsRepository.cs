using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Services
{
    public class MedicalAppointmentsRepository : IRespository
    {
        private IDbContext _dbContext;

        public MedicalAppointmentsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<IPatient> GetAllPatients()
        {
            using (var db = _dbContext)
            {
                var patients = db.Patients.ToList() as IList<IPatient>;
                return patients;
            }
        }

        public IList<IAppointmentType> GetAllAppointmentTypes()
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.ToList() as IList<IAppointmentType>;
                return appointmentTypes;
            }
        }

        public IList<IAppointment> GetAllAppointments()
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.ToList() as IList<IAppointment>;
                return appointments;
            }
        }

        public IPatient GetPatientById(int patiendId)
        {
            using (var db = _dbContext)
            {
                var patient = db.Patients.FirstOrDefault(p => p.Id.Equals(patiendId));
                return patient;
            }
        }

        public IList<IAppointment> GetAppointmentsByPatientId(int patiendId)
        {
            using (var db = _dbContext)
            {
                //var appointments = db.Appointments.FirstOrDefault(a => a.PatientId.Equals(patiendId) && a.IsActive) as IList<IAppointment>;
                var appointments = db.Patients.FirstOrDefault(p => p.Id.Equals(patiendId))?.Appointments as IList<IAppointment>;
                return appointments;
            }
        }

        public bool AddPatient(IPatient patient)
        {
            using (var db = _dbContext)
            {
                db.Patients.Add(patient as Patient);
                var result = db.SaveChanges();
                var isSaved = result.Equals(1) ? true : false;

                return isSaved;
            }
        }

        public bool AddAppointmentType(IAppointmentType appointmentType)
        {
            using (var db = _dbContext)
            {
                db.AppointmentTypes.Add(appointmentType as AppointmentType);
                var result = db.SaveChanges();
                var isSaved = result.Equals(1) ? true : false;

                return isSaved;
            }
        }

        public bool AddAppointment(IAppointment appointment)
        {
            using (var db = _dbContext)
            {
                db.Appointments.Add(appointment as Appointment);
                var result = db.SaveChanges();
                var isSaved = result.Equals(1) ? true : false;

                return isSaved;
            }
        }
    }
}
