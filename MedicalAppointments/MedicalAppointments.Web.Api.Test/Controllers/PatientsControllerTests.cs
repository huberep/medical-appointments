using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAppointments.Web.Api.Controllers;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using System.Web.Http.Results;
using System.Data.Entity;

namespace MedicalAppointments.Web.Api.Test.Controllers
{
    [TestClass()]
    public class PatientsControllerTests
    {
        [TestMethod()]
        public void GetAllPatient_Count_Patients_Returned_Test()
        {
            //Arrage
            IDbContext dbContext = new MedicalAppointmentContext();
            IRepository repository = new MedicalAppointmentsRepository(dbContext);
            var sut = new PatientsController(repository);
            var expectedResult = 5;

            //Act
            var result = sut.GetAll() as OkNegotiatedContentResult<List<Patient>>;
            var patientListResult = result.Content as List<Patient>;

            //Assert
            Assert.AreEqual(expectedResult, patientListResult.Count);
        }
    }
}
