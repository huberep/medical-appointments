using MedicalAppointments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
