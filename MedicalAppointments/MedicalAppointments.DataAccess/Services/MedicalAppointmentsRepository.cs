using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Services
{
    public class MedicalAppointmentsRepository : IRepository
    {
        private IDbContext _dbContext;

        public MedicalAppointmentsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Patient> GetAllPatients()
        {
            using (var db = _dbContext)
            {
                var patients = db.Patients.ToList();
                return patients;
            }
        }

        public List<AppointmentType> GetAllAppointmentTypes()
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.ToList();
                return appointmentTypes;
            }
        }

        public IAppointmentType GetAppointmentTypeById(int id)
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.FirstOrDefault(at => at.Id.Equals(id));
                return appointmentTypes;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.ToList();
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

        public List<Appointment> GetAppointmentsByPatientId(int patiendId)
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.Where(a => a.PatientId.Equals(patiendId) && a.IsActive).ToList();
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
                var isSaved = false;

                var appointments = db.Appointments.Where(a => a.PatientId.Equals(appointment.PatientId) && a.IsActive && a.Date > DateTime.Now).ToList();
                if (appointments.Count > 0)
                {
                    var existsAppointmentForDay = appointments.Exists(a => a.Date.Date.Equals(appointment.Date.Date));
                    if (!existsAppointmentForDay)
                    {
                        db.Appointments.Add(appointment as Appointment);
                        var result = db.SaveChanges();
                        isSaved = result.Equals(1) ? true : false;
                    }
                }

                return isSaved;
            }
        }

        public bool CancelAppointment(IAppointment appointment)
        {
            using (var db = _dbContext)
            {
                var isCancelled = false;

                var appointmentToCancel = db.Appointments.FirstOrDefault(a => a.Id.Equals(appointment.Id) && a.IsActive);
                var canBeCancelled = appointmentToCancel?.Date > DateTime.Now.AddHours(24) ? true : false;
                if (canBeCancelled)
                {
                    appointmentToCancel.IsActive = !canBeCancelled;
                    var result = db.SaveChanges();
                    isCancelled = result.Equals(1) ? true : false;
                }

                return isCancelled;
            }
        }
    }
}
