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
    public class PatientsController : ApiController
    {
        private readonly IRepository _repository;

        public PatientsController()
        {
            //TODO: Need to use Ninject to inject this dependencies and remove this constructor
            _repository = new PatientRepository(new MedicalAppointmentContext());
        }

        public PatientsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/patients")]
        public IHttpActionResult GetAll()
        {
            var result = _repository.GetAll() as IEnumerable<IPatient>;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/patients/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _repository.GetById(id) as IPatient;
            return Ok(result);
        }

        [HttpPost]
        [Route("api/patients/add")]
        public IHttpActionResult Add(Patient patient)
        {
            if (!ModelState.IsValid || !MedicalAppointmentsApiUtilities.IsValid(patient))
                return BadRequest("Invalid data.");

            var result = _repository.Add(patient);
            return Ok();
        }
    }
}