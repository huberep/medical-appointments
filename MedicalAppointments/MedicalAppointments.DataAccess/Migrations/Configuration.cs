namespace MedicalAppointments.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using MedicalAppointments.Common.Models;
    using MedicalAppointments.DataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalAppointmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MedicalAppointmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.AppointmentTypes.AddOrUpdate(
                new AppointmentType() { Id = 1, Name = "Medicina General" },
                new AppointmentType() { Id = 2, Name = "Odontología" },
                new AppointmentType() { Id = 3, Name = "Pediatría" },
                new AppointmentType() { Id = 4, Name = "Neurología" }
            );

            context.Patients.AddOrUpdate(
                new Patient() { Id = 1, IdCard = "206680338", Name = "Huber", Lastname = "Espinoza", DateOfBirth = new DateTime(1989, 11, 8)},
                new Patient() { Id = 2, IdCard = "503450354", Name = "Carlos", Lastname="Perez", DateOfBirth = new DateTime(1979, 10, 28) },
                new Patient() { Id = 3, IdCard = "704560234", Name = "Ana", Lastname = "Rojas", DateOfBirth = new DateTime(1999, 5, 15) },
                new Patient() { Id = 4, IdCard = "406540981", Name = "Maria", Lastname = "Mora", DateOfBirth = new DateTime(2017, 4, 12) },
                new Patient() { Id = 5, IdCard = "301240853", Name = "Juan", Lastname = "Castro", DateOfBirth = new DateTime(1969, 12, 22) }
            );

            context.Appointments.AddOrUpdate(
                new Appointment() { Id = 1, PatientId = 1, AppointmentTypeId = 1, Date = new DateTime(2019, 8, 10, 12, 30, 00), IsActive = true },  // 1.Huber - 1.General - Active
                new Appointment() { Id = 2, PatientId = 1, AppointmentTypeId = 2, Date = new DateTime(2019, 8, 12, 10, 15, 00), IsActive = false }, // 1.Huber - 2.Odontología - Cancelled

                new Appointment() { Id = 3, PatientId = 2, AppointmentTypeId = 2, Date = new DateTime(2019, 8, 10, 11, 45, 00), IsActive = true },  // 2.Carlos - 2.Odontología - Active
                new Appointment() { Id = 4, PatientId = 2, AppointmentTypeId = 4, Date = new DateTime(2019, 8, 11, 15, 30, 00), IsActive = true },  // 2.Carlos - 4.Neurología - Active

                new Appointment() { Id = 5, PatientId = 4, AppointmentTypeId = 3, Date = new DateTime(2019, 8, 10, 16, 00, 00), IsActive = true },  // 4.María - 3.Pediatría - Active

                new Appointment() { Id = 6, PatientId = 3, AppointmentTypeId = 1, Date = new DateTime(2019, 8, 11, 7, 20, 00), IsActive = false }   // 3.Ana - 1.General - Cancelled
            );
        }
    }
}
