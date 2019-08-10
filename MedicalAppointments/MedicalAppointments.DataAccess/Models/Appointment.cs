using MedicalAppointments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.DataAccess.Models
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
