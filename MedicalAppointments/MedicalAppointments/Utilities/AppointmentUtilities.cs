using System.Collections.Generic;
using System.Linq;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Models;

namespace MedicalAppointments.Utilities
{
    public class AppointmentUtilities
    {
        public static IEnumerable<AppointmentViewModel> CreateAppointmentsViewModel(IEnumerable<IAppointment> appointments, IEnumerable<IAppointmentType> appointmentTypes)
        {
            var result = new List<AppointmentViewModel>();

            if (appointments != null && appointmentTypes != null)
            {
                foreach (var appointment in appointments)
                {
                    var appointmentTypeName = appointmentTypes.FirstOrDefault(at => at.Id.Equals(appointment.AppointmentTypeId))?.Name;
                    var appointmentViewModel = new AppointmentViewModel(appointment.Id, appointmentTypeName, appointment.Date);
                    result.Add(appointmentViewModel);
                }
            }

            return result;
        }
    }
}