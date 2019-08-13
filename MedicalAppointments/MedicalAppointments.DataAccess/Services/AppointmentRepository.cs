using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;

namespace MedicalAppointments.DataAccess.Services
{
    public class AppointmentRepository : IRepository/*, IRepositoryCancel, IRespositoryGetByIdMultiple*/
    {
        private IDbContext _dbContext;

        public AppointmentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(IModel model)
        {
            using (var db = _dbContext)
            {
                var isSaved = false;
                var appointment = model as Appointment;

                var appointments = db.Appointments.Where(a => a.PatientId.Equals(appointment.PatientId) && a.IsActive && a.Date > DateTime.Now).ToList();
                if (appointments != null)
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

        public IModel Cancel(Appointment model)
        {
            using (var db = _dbContext)
            {
                var appointmentToCancel = db.Appointments.FirstOrDefault(a => a.Id.Equals(model.Id) && a.IsActive) as Appointment;
                var canBeCancelled = appointmentToCancel?.Date < DateTime.Now.AddHours(24) ? true : false;
                if (canBeCancelled)
                {
                    appointmentToCancel.IsActive = !canBeCancelled;
                    var result = db.SaveChanges();
                }

                return appointmentToCancel;
            }
        }

        public IEnumerable<IModel> GetAll()
        {
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.ToList();
                return appointments;
            }
        }

        public IModel GetById(int id)
        {
            using (var db = _dbContext)
            {
                var patient = db.Appointments.FirstOrDefault(p => p.Id.Equals(id));
                return patient;
            }
        }

        public IEnumerable<IModel> GetByPatientId(int id)
        {
            var patiendId = id;
            using (var db = _dbContext)
            {
                var appointments = db.Appointments.Where(a => a.PatientId.Equals(patiendId) && a.IsActive).ToList();
                return appointments;
            }
        }
    }
}
