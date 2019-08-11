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

        /// <summary>
        /// Gets All Patients
        /// </summary>
        /// <returns>List of Patients</returns>
        public List<Patient> GetAllPatients()
        {
            using (var db = _dbContext)
            {
                var patients = db.Patients.ToList();
                return patients;
            }
        }

        /// <summary>
        /// Gets All Appointment Types
        /// </summary>
        /// <returns>List of Appointment Types</returns>
        public List<AppointmentType> GetAllAppointmentTypes()
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.ToList();
                return appointmentTypes;
            }
        }

        /// <summary>
        /// Gets Appointment Type By Id
        /// </summary>
        /// <param name="id">Appointment Id</param>
        /// <returns>Appointment Type</returns>
        public IAppointmentType GetAppointmentTypeById(int id)
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.FirstOrDefault(at => at.Id.Equals(id));
                return appointmentTypes;
            }
        }

        /// <summary>
        /// Gets All Appointments
        /// </summary>
        /// <returns>List of All Appointments</returns>
        public List<Appointment> GetAllAppointments()
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.ToList();
                return appointments;
            }
        }

        /// <summary>
        /// Gets Patient by Id
        /// </summary>
        /// <param name="patiendId">Patient Id</param>
        /// <returns>Patient</returns>
        public IPatient GetPatientById(int patiendId)
        {
            using (var db = _dbContext)
            {
                var patient = db.Patients.FirstOrDefault(p => p.Id.Equals(patiendId));
                return patient;
            }
        }

        /// <summary>
        /// Gets Appointment's  Patient
        /// </summary>
        /// <param name="patiendId">Patient Id</param>
        /// <returns>List of Appointments</returns>
        public List<Appointment> GetAppointmentsByPatientId(int patiendId)
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.Where(a => a.PatientId.Equals(patiendId) && a.IsActive).ToList();
                return appointments;
            }
        }

        /// <summary>
        /// Adds Patient to Patient Table
        /// </summary>
        /// <param name="patient">Patient to Add</param>
        /// <returns>True whether patient was added, otherwise false</returns>
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

        /// <summary>
        /// Adds Appointment Type to Appointment Table
        /// </summary>
        /// <param name="appointmentType">Appointment Type</param>
        /// <returns>True whether appointment type was added, otherwise false</returns>
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

        /// <summary>
        /// Adds Appointment to Appointment Table
        /// Appointment can be added only when there is not appointment for same day
        /// </summary>
        /// <param name="appointment">Appointment to Add</param>
        /// <returns>True wheter appointment was added, otherwise false</returns>
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

        /// <summary>
        /// Cancels Appointment
        /// Appointment can be cancelled only when Appointment Date exceed 24 hours
        /// </summary>
        /// <param name="appointment">Appoint to Cancel</param>
        /// <returns>True whether appointment was cancelled, otherwise false</returns>
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
