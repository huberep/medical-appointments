using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IAppointment
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        bool IsActive { get; set; }
        int PatientId { get; set; }
        int AppointmentTypeId { get; set; }
    }
}
