﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAppointments;
using MedicalAppointments.Controllers;

namespace MedicalAppointments.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
            //ViewResult result = await controller.Patient() as ViewResult;

            // Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message); 
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Appointment() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
