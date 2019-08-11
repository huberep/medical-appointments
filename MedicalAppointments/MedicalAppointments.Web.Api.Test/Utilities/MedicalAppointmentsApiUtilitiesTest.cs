using System;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sut = MedicalAppointments.Web.Api.Utilities.MedicalAppointmentsApiUtilities;

namespace MedicalAppointments.Web.Api.Test.Utilities
{
    [TestClass()]
    public class MedicalAppointmentsApiUtilitiesTest
    {
        /*Patient test*/

        [TestMethod()]
        public void Patient_NotValid_DefaultConstructor_Test()
        {
            //Arrage
            var patient = new Patient();

            //Act
            var result = sut.IsValid(patient);
            
            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_NotValid_Id_Test()
        {
            //Arrage
            var patient = new Patient() { Id = -1 };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_NotValid_IdCard_Test()
        {
            //Arrage
            var patient = new Patient() { Id = 1, IdCard = string.Empty };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_NotValid_Name_Test()
        {
            //Arrage
            var patient = new Patient() { Id = 1, IdCard = "206680338", Name = string.Empty };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_NotValid_Lastname_Test()
        {
            //Arrage
            var patient = new Patient() { Id = 1, IdCard = "206680338", Name = "Huber", Lastname = string.Empty };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_NotValid_DateOfBirth_Test()
        {
            //Arrage
            var patient = new Patient() { Id = 1, IdCard = "206680338", Name = "Huber", Lastname = "Espinoza", DateOfBirth = DateTime.MinValue };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Patient_Valid_Test()
        {
            //Arrage
            var patient = new Patient() { Id = 1, IdCard = "206680338", Name = "Huber", Lastname = "Espinoza", DateOfBirth = DateTime.Now };

            //Act
            var result = sut.IsValid(patient);

            //Assert
            Assert.IsTrue(result);
        }


        /*Appointment type tests*/

        [TestMethod()]
        public void AppointmentType_NotValid_DefaultConstructor_Test()
        {
            //Arrage
            var appointmentType = new AppointmentType();

            //Act
            var result = sut.IsValid(appointmentType);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void AppointmentType_NotValid_Id_Test()
        {
            //Arrage
            var appointmentType = new AppointmentType() { Id = -1 };

            //Act
            var result = sut.IsValid(appointmentType);

            //Assert
            Assert.IsTrue(!result);
        }

        
        [TestMethod()]
        public void AppointmentType_NotValid_Name_Test()
        {
            //Arrage
            var appointmentType = new AppointmentType() { Id = 1, Name = string.Empty };

            //Act
            var result = sut.IsValid(appointmentType);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void AppointmentType_Valid_Test()
        {
            //Arrage
            var appointmentType = new AppointmentType() { Id = 1, Name = "Radiología" };

            //Act
            var result = sut.IsValid(appointmentType);

            //Assert
            Assert.IsTrue(result);
        }

        /*Appointments tests*/

        [TestMethod()]
        public void Appointment_NotValid_DefaultConstructor_Test()
        {
            //Arrage
            var appointment = new Appointment();

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Appointment_NotValid_Id_Test()
        {
            //Arrage
            var appointment = new Appointment() { Id = -1 };

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Appointment_NotValid_ParentId_Test()
        {
            //Arrage
            var appointment = new Appointment() { Id = 1, PatientId = -1 };

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Appointment_NotValid_AppointmentTypeId_Test()
        {
            //Arrage
            var appointment = new Appointment() { Id = 1, PatientId = 1, AppointmentTypeId = -1 };

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Appointment_NotValid_Date_Test()
        {
            //Arrage
            var appointment = new Appointment() { Id = 1, PatientId = 1, AppointmentTypeId = 1, Date = DateTime.MinValue };

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod()]
        public void Appointment_Valid_Test()
        {
            //Arrage
            var appointment = new Appointment() { Id = 1, PatientId = 1, AppointmentTypeId = 1, Date = DateTime.Now, IsActive = true };

            //Act
            var result = sut.IsValid(appointment);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
