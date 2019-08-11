using System;
using System.Data.Entity;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.DataAccess.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<AppointmentType> AppointmentTypes { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        int SaveChanges();
    }
}
