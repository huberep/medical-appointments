using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using MedicalAppointments.Common.Interfaces;
using MedicalAppointments.Common.Models;

namespace MedicalAppointments.Controllers
{
    public class PatientController : Controller
    {
        private readonly string apiUri = ConfigurationManager.AppSettings["ApiUri"];
        private readonly string uriFormat = "{0}{1}";

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
    }
}