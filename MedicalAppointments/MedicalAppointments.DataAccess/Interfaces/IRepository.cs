using System.Collections.Generic;
using MedicalAppointments.Common.Interfaces;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IRepository
    {
        IEnumerable<IModel> GetAll();
        IModel GetById(int id);
        bool Add(IModel model);
    }
}
