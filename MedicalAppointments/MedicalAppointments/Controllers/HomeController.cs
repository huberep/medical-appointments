using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly string apiUri = ConfigurationManager.AppSettings["ApiUri"];
        private readonly string uriFormat = "{0}{1}";

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Patient()
        {
            ViewBag.Message = "Manage patients appointments";
            IEnumerable<IPatient> patients = null;

            using (var httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormat, apiUri, @"patients");

                var response = await httpClient.GetAsync(uri);
                patients = await response.Content.ReadAsAsync<List<Patient>>();
            }

            return View(patients);
        }
        public async Task<ActionResult> Appointment(int id)
        {
            ViewBag.Message = "Patient Appointments";
            ViewBag.PatiendId = id;
            IEnumerable<AppointmentViewModel> appointmentsViewModel = new List<AppointmentViewModel>();

            using (var httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormat, apiUri, @"appointments/patient/" + id.ToString());

                var appointmentsResponse = await httpClient.GetAsync(uri);
                IEnumerable<IAppointment> appointments = await appointmentsResponse.Content.ReadAsAsync<List<Appointment>>();

                uri = string.Format(uriFormat, apiUri, @"appointmentTypes");

                var appointmentTypeResponse = await httpClient.GetAsync(uri);
                IEnumerable<IAppointmentType> appointmentTypes = await appointmentTypeResponse.Content.ReadAsAsync<List<AppointmentType>>();

                appointmentsViewModel = AppointmentUtilities.CreateAppointmentsViewModel(appointments, appointmentTypes);
            }

            return View(appointmentsViewModel);
        }

        public ActionResult AddAppointment(int id)
        {
            var appointmentViewModel = new AppointmentViewModel() { PatientId = id };
            return View(appointmentViewModel);
        }

        public ActionResult Cancel(int id, int patientId)
        {
            var appointment = new Appointment() { Id = id, PatientId = patientId };
            using (var httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormat, apiUri, @"appointments/cancel");

                var cancelTask = httpClient.PostAsJsonAsync<Appointment>(uri, appointment);
                cancelTask.Wait();

                var result = cancelTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Appointment", new { id = patientId });
                }
            }

            return RedirectToAction("Appointment", new { id = patientId });
        }

        [HttpPost]
        public ActionResult Add(int appointmentTypeId, DateTime appointmentDate, TimeSpan appointmentTime, int patientId)
        {
            DateTime date = appointmentDate + appointmentTime;
            Appointment appointment = new Appointment() { Id = 1, PatientId = patientId, Date = date, AppointmentTypeId = appointmentTypeId, IsActive = true };

            using (var httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormat, apiUri, @"appointments/add");

                var postTask = httpClient.PostAsJsonAsync<Appointment>(uri, appointment);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Appointment", new { id = patientId });
                }
            }

            return RedirectToAction("AddAppointment", new { id = patientId });
        }
    }
}