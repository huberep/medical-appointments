using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;

namespace MedicalAppointments.DataAccess.Services
{
    public class AppointmentTypeRepository : IRepository
    {
        private IDbContext _dbContext;

        public AppointmentTypeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(IModel model)
        {
            using (var db = _dbContext)
            {
                db.AppointmentTypes.Add(model as AppointmentType);
                var result = db.SaveChanges();
                var isSaved = result.Equals(1) ? true : false;

                return isSaved;
            }
        }

        public IEnumerable<IModel> GetAll()
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.ToList();
                return appointmentTypes;
            }
        }

        public IModel GetById(int id)
        {
            using (var db = _dbContext)
            {
                var appointmentTypes = db.AppointmentTypes.FirstOrDefault(at => at.Id.Equals(id));
                return appointmentTypes;
            }
        }
    }
}
