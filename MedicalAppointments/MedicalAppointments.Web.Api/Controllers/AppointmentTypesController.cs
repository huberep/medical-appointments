using System.Web.Http;
using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Utilities;

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

        [HttpPost]
        [Route("api/appointmentTypes/add")]
        public IHttpActionResult Add(AppointmentType appointmentType)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(appointmentType))
                return BadRequest("Invalid data.");

            var result = _repository.AddAppointmentType(appointmentType);
            return Ok();
        }
    }
}