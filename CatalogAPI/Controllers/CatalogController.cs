using Microsoft.AspNetCore.Mvc;


namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        // Get-metode, som testen kan kalde på
        [HttpGet]
        public IActionResult AddProduct()
        {
            return Ok();  // Returnerer HTTP 200 OK 
        }
        
        
       
    }
}



/*
[HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product newProduct)
        {
            try
            {
                // Inputvalidering: Sørger for at produktet har nødvendige felter (f.eks. navn og vurdering)
                if (newProduct == null || string.IsNullOrEmpty(newProduct.Name) || newProduct.Valuation <= 0)
                {
                    _logger.LogWarning("Invalid product data received: {Product}", newProduct);
                    return BadRequest("Produktet er ikke gyldigt. Sørg for at have et navn og en positiv pris.");
                }

                // Hvis produktet ikke har et ID, opret et nyt
                if (newProduct.Id == Guid.Empty)
                {
                    newProduct.Id = Guid.NewGuid();
                }

                // Indsæt produktet i databasen
                await _productCollection.InsertOneAsync(newProduct);

                // Returner en CreatedAtRouteResult med det oprettede produkt
                _logger.LogInformation("Product added with ID: {ProductId}", newProduct.Id);
                return CreatedAtRoute("GetProductById", new { productId = newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                // Hvis noget går galt, f.eks. i forbindelse med databasen, returner en serverfejl
                _logger.LogError(ex, "Error while adding product");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        */
