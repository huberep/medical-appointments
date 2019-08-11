using MedicalAppointments.Common.Models;
using System.Data.Entity;
using MedicalAppointments.DataAccess.Interfaces;

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
