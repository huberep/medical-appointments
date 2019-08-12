using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalAppointments.Web.Api.Test.Controllers
{
   [TestClass()]
    public class AppointmentsControllerTests
    {
        [TestMethod()]
        public void GetAllAppointments_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<IEnumerable<IAppointment>>;
            var appointmentListResult = result.Content as List<Appointment>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(appointmentListResult);
        }

        [TestMethod()]
        public void GetAllAppointments_Count_AppointmentsResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var expectedResult = 6;

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<IEnumerable<IAppointment>>;
            var appointmentListResult = result.Content as List<Appointment>;

            //Assert
            Assert.AreEqual(expectedResult, appointmentListResult.Count);
        }

        [TestMethod()]
        public void GetAppointmentByPatientId_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IEnumerable<IAppointment>>;
            var appointmentListResult = result.Content as List<Appointment>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(appointmentListResult);
        }

        [TestMethod()]
        public void GetAppointmentsByPatientId_Count_AppointmentsResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var expectedResult = 1;

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IEnumerable<IAppointment>>;
            var appointmentListResult = result.Content as List<Appointment>;
            
            //Assert
            Assert.AreEqual(expectedResult, appointmentListResult.Count);
        }

        [TestMethod()]
        public void GetAppointmentsByPatientId_ValidDataResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var expectedResult = new Appointment() { Id = 1, PatientId = 1, AppointmentTypeId = 1, Date = new DateTime(2019, 8, 10, 12, 30, 00), IsActive = true };

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IEnumerable<IAppointment>>;
            var appointmentListResult = result.Content as List<Appointment>;
            var appointmentResult = appointmentListResult.First();

            //Assert
            Assert.AreEqual(expectedResult.Id, appointmentResult.Id);
            Assert.AreEqual(expectedResult.PatientId, appointmentResult.PatientId);
            Assert.AreEqual(expectedResult.AppointmentTypeId, appointmentResult.AppointmentTypeId);
            Assert.AreEqual(expectedResult.Date, appointmentResult.Date);
            Assert.AreEqual(expectedResult.IsActive, appointmentResult.IsActive);
        }

        [TestMethod()]
        public void AddAppointment_InvalidData_BadRequest_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var appointmentToAdd = new Appointment();
            
            //Act
            var result = sut.Add(appointmentToAdd);

            //Assert
            Assert.IsTrue(result is BadRequestErrorMessageResult);
        }

        [TestMethod()]
        public void AddAppointment_AppointmentSameDay_NotAdded_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var appointmentToAdd = new Appointment() { Id = 4, PatientId = 2, AppointmentTypeId = 4, Date = new DateTime(2019, 8, 11, 15, 30, 00), IsActive = true };

            //Act
            var result = sut.Add(appointmentToAdd) as OkNegotiatedContentResult<bool>;

            //Assert
            Assert.IsTrue(!result.Content);
        }

        [TestMethod()]
        public void CancelAppointment_InvalidData_BadRequest_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var appointmentToCancel = new Appointment();

            //Act
            var result = sut.Cancel(appointmentToCancel);

            //Assert
            Assert.IsTrue(result is BadRequestErrorMessageResult);
        }

        [TestMethod()]
        public void CancelAppointment_AppointmentDateMoreThan24Hours_NotCancelled_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new AppointmentRepository(dbContext);
            var sut = new AppointmentsController(repository);
            var appointmentToCancel = new Appointment() { Id = 4, PatientId = 2, AppointmentTypeId = 4, Date = new DateTime(2019, 8, 11, 15, 30, 00), IsActive = true };

            //Act
            var result = sut.Cancel(appointmentToCancel) as OkNegotiatedContentResult<bool>;

            //Assert
            Assert.IsTrue(!result.Content);
        }
    }
}
