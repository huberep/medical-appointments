using System;

namespace MedicalAppointments.Models
{
    public class AppointmentViewModel
    {
        public int Id { set; get; }
        public string AppointmentTypeName { get; set; }
        public DateTime Date { get; set; }
        public bool CanBeCancelled
        {
            get
            {
                return Date > DateTime.Now && Date< DateTime.Now.AddHours(24);
            }
        }

        public AppointmentViewModel() { }

        public AppointmentViewModel(int id, string appointmentTypeName, DateTime date)
        {
            this.Id = id;
            this.AppointmentTypeName = appointmentTypeName;
            this.Date = date;
        }
    }
}