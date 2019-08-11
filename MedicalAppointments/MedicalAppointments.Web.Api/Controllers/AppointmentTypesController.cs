﻿using MedicalAppointments.DataAccess.Interfaces;
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
    public class AppointmentTypesController : ApiController
    {
        private IRepository _repository;

        public AppointmentTypesController()
        {
            _repository = new MedicalAppointmentsRepository(new MedicalAppointmentContext());
        }

        public AppointmentTypesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/appointmentTypes")]
        public IHttpActionResult GetAll()
        {
            var result = _repository.GetAllAppointmentTypes();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/appointmentTypes/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetAppointmentTypeById(id);

            return Ok(result);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}