using MedicalAppointments.Common.Models;
using System;

namespace MedicalAppointments.Models
{
    public class AppointmentViewModel
    {
        public int Id { set; get; }
        public int PatientId { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public DateTime Date { get; set; }
        public bool CanBeCancelled
        {
            get
            {
                return Date > DateTime.Now && Date< DateTime.Now.AddHours(24);
            }
        }

        public AppointmentViewModel() { }

        public AppointmentViewModel(int id, int patientId, AppointmentType appointmentType, DateTime date)
        {
            this.Id = id;
            this.PatientId = patientId;
            this.AppointmentType = appointmentType;
            this.Date = date;
        }
    }
}