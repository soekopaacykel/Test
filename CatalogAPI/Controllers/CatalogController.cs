using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        // Get-metode, som testen kan kalde på
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok();  // Returnerer HTTP 200 OK 
        }
        
        
       
    }
}



