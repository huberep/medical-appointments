using System.Web.Mvc;
using MedicalAppointments.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalAppointments.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ViewResult_NotNull_Test()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
