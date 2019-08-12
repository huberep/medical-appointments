using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;
using MedicalAppointments.Models;
using MedicalAppointments.Utilities;

namespace MedicalAppointments.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Patient()
        {
            ViewBag.Message = "Manage patient's appointments from here";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44362/api/patients");
            IEnumerable<IPatient> patients = await response.Content.ReadAsAsync<List<Patient>>();

            return View(patients);
        }

        public async Task<ActionResult> Appointment(int id, string name, string lastname)
        {
            string messageFormat = "{0} {1}'s Appointments";
            ViewBag.Message = string.Format(messageFormat, name, lastname);

            var httpClient = new HttpClient();
            var url = "https://localhost:44362/api/appointments/" + id.ToString();
            var appointmentsResponse = await httpClient.GetAsync(url);
            IEnumerable<IAppointment> appointments = await appointmentsResponse.Content.ReadAsAsync<List<Appointment>>();

            url = "https://localhost:44362/api/appointmentTypes/";
            var appointmentTypeResponse = await httpClient.GetAsync(url);
            IEnumerable<IAppointmentType> appointmentTypes = await appointmentTypeResponse.Content.ReadAsAsync<List<AppointmentType>>();

            var appointmentsViewModel = AppointmentUtilities.CreateAppointmentsViewModel(appointments, appointmentTypes);

            return View(appointmentsViewModel);
        }

        public ActionResult AddAppointment()
        {

            return View();
        }

        public ActionResult Create(AppointmentViewModel appointment)
        {

            return View();
        }
    }
}