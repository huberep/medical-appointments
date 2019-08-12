using System.Collections.Generic;
using System.Web.Http;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Utilities;

namespace MedicalAppointments.Web.Api.Controllers
{
    public class AppointmentsController : ApiController
    {
        private IRepository _repository;

        public AppointmentsController()
        {
            _repository = new AppointmentRepository(new MedicalAppointmentContext());
        }

        public AppointmentsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/appointments")]
        public IHttpActionResult GetAll()
        {
            var result = _repository.GetAll() as IEnumerable<IAppointment>;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/appointments/{patientId}")]
        public IHttpActionResult Get(int patientId)
        {
            var result = (_repository as AppointmentRepository).GetByPatientId(patientId) as IEnumerable<IAppointment>;
            return Ok(result);
        }

        [HttpPost]
        [Route("api/appointments/add")]
        public IHttpActionResult Add(Appointment appointment)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(appointment))
                return BadRequest("Invalid data.");

            var result = _repository.Add(appointment);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/appointments/cancel")]
        public IHttpActionResult Cancel(Appointment appointment)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(appointment))
                return BadRequest("Invalid data.");

            var result = (_repository as AppointmentRepository).Cancel(appointment);
            return Ok(result);
        }
    }
}