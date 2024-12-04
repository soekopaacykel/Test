using CatalogAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogAPI.Tests
{
    [TestClass] 
    public class CatalogControllerTests
    {

        [TestMethod] 
        public void GetProduct_FindesIkke()
        {
            // Arrange
            var controller = new CatalogController();

            // Act
            var result = controller.GetProduct(); // Forsøger at hente produktet

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult)); // Forventer HTTP 200 OK
        }
    }
}
