using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace CatalogAPI.Controllers
{

    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMongoCollection<Product> _productCollection;

        public CatalogController(IMongoCollection<Product> productCollection)
        {
            _productCollection = productCollection;
        }

        // Post-metode, som testen kan kalde på
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            // Hvis produktet ikke har et ID, opret et nyt
            if (newProduct.Id == 0)
            {
                newProduct.Id = 1;
            }
            // Indsæt produktet i databasen
            await _productCollection.InsertOneAsync(newProduct);

            // Returner en OkResult med en besked
            return Ok("Har lavet lortet");
        }

    }


    public class Product
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

