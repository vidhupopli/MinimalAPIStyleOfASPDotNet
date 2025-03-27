// Controllers are just files that define the endpoint spec.
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using Microsoft.Extensions.Logging;

namespace MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/shirts")] // This is an attribute we may use both at class level and the method level. It defines the path spec.
    public class ShirtsController: ControllerBase
    {
        private readonly ILogger<ShirtsController> _logger;

        private List<Shirt> ShirtsDb = new List<Shirt>()
        {
            new Shirt() { ShirtId=1, Color="Red", Size="XL", Gender="Male", Price=2000 },
            new Shirt() { ShirtId=2, Color="Blue", Size="XXL", Gender="Male", Price=3000 },
            new Shirt() { ShirtId=3, Color="Pink", Size="M", Gender="Female", Price=4000 }
        };

        public ShirtsController(ILogger<ShirtsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetShirts([FromQuery] int? Id)
        {
            if (Id == null)
            {
                return Ok(ShirtsDb);
            }
               
            if (Id < 0)
            {
                return BadRequest();
            }

            var FoundShirt = ShirtsDb.FirstOrDefault(ShirtInstance => ShirtInstance.ShirtId == Id);
            if (FoundShirt == null)
            {
                return BadRequest();
            }

            return Ok(FoundShirt);
        }

        [HttpGet("{Id}")] // This is path spec using a param.
        public string GetSpecificShirt([FromRoute] int Id, [FromQuery] string? color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                return $"route param: {Id} | queryParam: {color}";
            }

            return $"Route param: ${Id}";
        }

        [HttpGet]
        [Route("secret")] // Defines path spec.
        public string GetSecretShirt([FromHeader(Name = "Authorization")] string? authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                return "You are not authorized!";
            }

            return "Here is your secret shirt";
        }
        
        [HttpPost]
        public string CreateSpecificShirt([FromBody] Shirt shirt) // By default this is JSON.
        //public string CreateSpecificShirt([FromForm] Shirt shirt) // Instead of JSON, you can get Form Data
        {
            _logger.LogInformation("About to return a response");
            return $"{shirt.ShirtId} - {shirt.Color} - {shirt.Size} - {shirt.Price}";
        }

        [HttpPut]
        [Route("{Id}")]
        public string UpdateSpecificShirt(int Id)
        {
            return $"Updating specific shirt: {Id}";
        }

        [HttpDelete]
        [Route("{Id}")]
        public string DeletingSpecificShirt(int Id)
        {
            return $"Deleting specific shirt: {Id}";
        }
    }
}
