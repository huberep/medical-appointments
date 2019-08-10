using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IAppointmentType
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
