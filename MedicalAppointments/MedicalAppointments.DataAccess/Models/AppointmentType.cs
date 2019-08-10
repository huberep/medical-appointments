using MedicalAppointments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.DataAccess.Models
{
    public class AppointmentType : IAppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
