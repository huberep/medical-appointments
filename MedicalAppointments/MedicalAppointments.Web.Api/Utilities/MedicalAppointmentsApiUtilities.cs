using System;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.Web.Api.Utilities
{
    public class MedicalAppointmentsApiUtilities
    {
        public static bool IsValid(Patient patient)
        {
            var isValid = true;

            if (patient == null)
                return false;
            else if (patient.Id <= 0)
                return false;
            else if (string.IsNullOrEmpty(patient.IdCard))
                return false;
            else if (string.IsNullOrEmpty(patient.Name))
                return false;
            else if (string.IsNullOrEmpty(patient.Lastname))
                return false;
            else if (patient.DateOfBirth.Equals(DateTime.MinValue))
                return false;

            return isValid;
        }

        public static bool IsValid(AppointmentType appointmentType)
        {
            var isValid = true;

            if (appointmentType == null)
                return false;
            else if (appointmentType.Id <= 0)
                return false;
            else if (string.IsNullOrEmpty(appointmentType.Name))
                return false;

            return isValid;
        }

        public static bool IsValid(Appointment appointment)
        {
            var isValid = true;

            if (appointment == null)
                return false;
            else if (appointment.Id <= 0)
                return false;
            else if (appointment.PatientId <= 0)
                return false;
            else if (appointment.AppointmentTypeId <= 0)
                return false;
            else if (appointment.Date.Equals(DateTime.MinValue))
                return false;

            return isValid;
        }
    }
}