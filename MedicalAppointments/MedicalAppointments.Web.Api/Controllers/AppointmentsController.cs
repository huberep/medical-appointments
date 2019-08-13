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
        private readonly IRepository _repository;

        public AppointmentsController()
        {
            //TODO: Need to use Ninject to inject this dependencies and remove this constructor
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
        [Route("api/appointments/patient/{patientId}")]
        public IHttpActionResult GetByPatientId(int patientId)
        {
            var result = (_repository as AppointmentRepository).GetByPatientId(patientId) as IEnumerable<IAppointment>;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/appointments/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetById(id) as IEnumerable<IAppointment>;
            return Ok(result);
        }

        [HttpPost]
        [Route("api/appointments/add")]
        public IHttpActionResult Add([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(appointment))
                return BadRequest("Invalid data.");

            var result = _repository.Add(appointment);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/appointments/cancel")]
        public IHttpActionResult Cancel([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = (_repository as AppointmentRepository).Cancel(appointment) as IAppointment;
            return Ok(result);
        }
    }
}