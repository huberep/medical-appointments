using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAppointments.Web.Api.Controllers
{
    public class PatientsController : ApiController
    {
        private IRepository _repository;

        public PatientsController()
        {
            _repository = new MedicalAppointmentsRepository(new MedicalAppointmentContext());
        }

        public PatientsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/patients")]
        public IHttpActionResult GetAll()
        {
            var result = _repository.GetAllPatients();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/patients/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetPatientById(id);

            return Ok(result);
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
    }
}