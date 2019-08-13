using System.Collections.Generic;
using System.Linq;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
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
                    var appointmentType = appointmentTypes.FirstOrDefault(at => at.Id.Equals(appointment.AppointmentTypeId)) as AppointmentType;
                    var appointmentViewModel = new AppointmentViewModel(appointment.Id, appointment.PatientId, appointmentType, appointment.Date, appointment.IsActive);
                    result.Add(appointmentViewModel);
                }
            }

            return result;
        }
    }
}