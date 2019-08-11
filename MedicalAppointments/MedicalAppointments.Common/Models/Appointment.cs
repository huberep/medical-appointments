using System;
using MedicalAppointments.Common.Interfaces;

namespace MedicalAppointments.Common.Models
{
    public class Appointment : IAppointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AppointmentTypeId { get; set; }
        public AppointmentType AppointmentType { get; set; }
    }
}
