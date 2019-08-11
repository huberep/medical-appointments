using System.Collections.Generic;
using System.Web.Http.Results;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalAppointments.Web.Api.Test.Controllers
{
    [TestClass()]
    public class AppointmentTypesControllerTests
    {
        [TestMethod()]
        public void GetAllAppointmentTypes_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new AppointmentTypesController(repository);

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<List<AppointmentType>>;
            var appointmentTypeListResult = result.Content as List<AppointmentType>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(appointmentTypeListResult);
        }

        [TestMethod()]
        public void GetAllAppointmentTypes_Count_PatientsResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new AppointmentTypesController(repository);
            var expectedResult = 4;

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<List<AppointmentType>>;
            var appointmentTypeListResult = result.Content as List<AppointmentType>;

            //Assert
            Assert.AreEqual(expectedResult, appointmentTypeListResult.Count);
        }

        [TestMethod()]
        public void GetAppointmentTypeById_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new AppointmentTypesController(repository);

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IAppointmentType>;
            var appointmentTypeResult = result.Content as AppointmentType;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(appointmentTypeResult);
        }

        [TestMethod()]
        public void GetAppointmentTypeById_ValidDataResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new AppointmentTypesController(repository);
            var expectedResult = new AppointmentType() { Id = 1, Name = "Medicina General" };

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IAppointmentType>;
            var appointmentTypeResult = result.Content as AppointmentType;

            //Assert
            Assert.AreEqual(expectedResult.Id, appointmentTypeResult.Id);
            Assert.AreEqual(expectedResult.Name, appointmentTypeResult.Name);
        }

        [TestMethod()]
        public void AddAppointmentType_InvalidData_BadRequest_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new AppointmentTypesController(repository);
            var appointmentTypeToAdd = new AppointmentType();

            //Act
            var result = sut.Add(appointmentTypeToAdd);

            //Assert
            Assert.IsTrue(result is BadRequestErrorMessageResult);
        }
    }
}
