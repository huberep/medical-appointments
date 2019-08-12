using System;
using System.Collections.Generic;
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
    public class PatientsControllerTests
    {
        [TestMethod()]
        public void GetAllPatients_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<IEnumerable<IPatient>>;
            var patientListResult = result.Content as IEnumerable<IPatient>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(patientListResult);
        }

        [TestMethod()]
        public void GetAllPatients_Count_PatientsResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);
            var expectedResult = 5;

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<IEnumerable<IPatient>>;
            var patientListResult = result.Content as List<Patient>;

            //Assert
            Assert.AreEqual(expectedResult, patientListResult.Count);
        }

        [TestMethod()]
        public void GetPatientById_NotNullResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);
            
            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IPatient>;
            var patientResult = result.Content as Patient;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(patientResult);
        }

        [TestMethod()]
        public void GetPatientById_ValidDataResponse_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);
            var expectedResult = new Patient() { Id = 1, IdCard = "206680338", Name = "Huber", Lastname = "Espinoza", DateOfBirth = new DateTime(1989, 11, 8) };

            //Act
            var result = sut.Get(1) as OkNegotiatedContentResult<IPatient>;
            var patientResult = result.Content as Patient;

            //Assert
            Assert.AreEqual(expectedResult.Id, patientResult.Id);
            Assert.AreEqual(expectedResult.IdCard, patientResult.IdCard);
            Assert.AreEqual(expectedResult.Name, patientResult.Name);
            Assert.AreEqual(expectedResult.Lastname, patientResult.Lastname);
            Assert.AreEqual(expectedResult.DateOfBirth, patientResult.DateOfBirth);
        }

        [TestMethod()]
        public void AddPatient_InvalidData_BadRequest_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);
            var patientToAdd = new Patient();

            //Act
            var result = sut.Add(patientToAdd);

            //Assert
            Assert.IsTrue(result is BadRequestErrorMessageResult);
        }
    }
}
