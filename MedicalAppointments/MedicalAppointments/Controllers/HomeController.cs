using MedicalAppointments.Common.Models;
using MedicalAppointments.DataAccess.Interfaces;
using MedicalAppointments.DataAccess.Models;
using MedicalAppointments.DataAccess.Services;
using MedicalAppointments.Web.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.Message = "You can manage your patient's appointments from here";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44362/api/patients");
            IEnumerable<IPatient> patients = await response.Content.ReadAsAsync<List<Patient>>();

            return View(patients);
        }

        public ActionResult Appointment()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}