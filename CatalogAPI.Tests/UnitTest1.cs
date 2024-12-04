using CatalogAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CatalogAPI.Tests
{
    [TestClass]
    public class Tests
    {
        private Mock<IMongoCollection<Product>> _mockProductCollection;
        private CatalogController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Opsætning af mocks
            _mockProductCollection = new Mock<IMongoCollection<Product>>();

            // Opret controlleren med både mock af IMongoCollection
            _controller = new CatalogController(_mockProductCollection.Object);
        }

        [TestMethod]
        public async Task AddProduct_Findes()
        {
            // Arrange
            // Vi har allerede controlleren i Setup() metoden
            // Act
            var result = await _controller.AddProduct(new Product()); 

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task AddProduct_GiverBesked()
        {
            // Arrange
            var expectedMessage = "Har lavet lortet";

            // Act
            var result = await _controller.AddProduct(new Product()); 

            // Assert
            var okResult = result as OkObjectResult; // Få fat i OkObjectResult
            Assert.AreEqual(expectedMessage, okResult.Value); // Kontrollér at beskeden matcher
        }

        [TestMethod]
        public async Task AddProduct_OprettesIMongoDB()
        {
            // Arrange
            var newProduct = new Product
            {
                Id = 0,  // Test case where ID is 0 and should be generated
                Name = "Test Product",
                Description = "Test description",
                Price = 100.0M
            };

            // Act
            var result = await _controller.AddProduct(newProduct); // Sørg for at kalde AddProduct asynkront

            // Assert
            _mockProductCollection.Verify(m => m.InsertOneAsync(It.IsAny<Product>(), null, default), Times.Once);
        }
    }
}






