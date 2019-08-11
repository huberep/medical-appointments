using System.Web.Http;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Utilities;

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

        [HttpPost]
        [Route("api/patients/add")]
        public IHttpActionResult Add(Patient patient)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(patient))
                return BadRequest("Invalid data.");

            var result = _repository.AddPatient(patient);
            return Ok();
        }
    }
}