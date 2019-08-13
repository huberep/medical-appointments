using System;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.Models
{
    public class AppointmentViewModel
    {
        public int Id { set; get; }
        public int PatientId { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public bool CanBeCancelled
        {
            get
            {
                return (Date > DateTime.Now && Date< DateTime.Now.AddHours(24)) && IsActive;
            }
        }

        public string Status
        {
            get
            {
                return IsActive ? "Yes" : "No";
            }
        }

        public AppointmentViewModel() { }

        public AppointmentViewModel(int id, int patientId, AppointmentType appointmentType, DateTime date, bool isActive)
        {
            this.Id = id;
            this.PatientId = patientId;
            this.AppointmentType = appointmentType;
            this.Date = date;
            this.IsActive = isActive;
        }
    }
}