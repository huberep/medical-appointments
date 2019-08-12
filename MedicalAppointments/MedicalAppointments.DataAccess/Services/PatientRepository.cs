using System.Collections.Generic;
using System.Linq;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;

namespace MedicalAppointments.DataAccess.Services
{
    public class PatientRepository : IRepository
    {
        private IDbContext _dbContext;

        public PatientRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(IModel model)
        {
            using (var db = _dbContext)
            {
                db.Patients.Add(model as Patient);
                var result = db.SaveChanges();
                var isSaved = result.Equals(1) ? true : false;

                return isSaved;
            }
        }

        public IEnumerable<IModel> GetAll()
        {
            using (var db = _dbContext)
            {
                var patients = db.Patients.ToList();
                return patients;
            }
        }

        public IModel GetById(int id)
        {
            using (var db = _dbContext)
            {
                var patient = db.Patients.FirstOrDefault(p => p.Id.Equals(id));
                return patient;
            }
        }
    }
}
