using MedicalAppointments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace MedicalAppointments.DataAccess.Models
{
    public class MedicalAppointmentContext : DbContext, IDbContext
    {
        public MedicalAppointmentContext() : base("DefaultConnection") { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
