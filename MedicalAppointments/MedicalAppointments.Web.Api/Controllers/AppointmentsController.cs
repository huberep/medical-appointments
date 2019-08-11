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
    public class AppointmentsController : ApiController
    {
        private IRepository _repository;

        public AppointmentsController()
        {
            _repository = new MedicalAppointmentsRepository(new MedicalAppointmentContext());
        }

        public AppointmentsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/appointments")]
        public IHttpActionResult GetAll()
        {
            var result = _repository.GetAllAppointments();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/appointments/{patientId}")]
        public IHttpActionResult Get(int patientId)
        {
            var result = _repository.GetAppointmentsByPatientId(patientId);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/appointments/add")]
        public IHttpActionResult Add(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = _repository.AddAppointment(appointment);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/appointments/cancel")]
        public IHttpActionResult Cancel(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = _repository.CancelAppointment(appointment);
            return Ok(result);
        }
    }
}