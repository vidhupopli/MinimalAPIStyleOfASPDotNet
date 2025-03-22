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

        public ShirtsController(ILogger<ShirtsController> logger)
        {
            _logger = logger;
        }

        // Query params means you do not use separate routes. You utilize existing ones.
        // Here this is a generic route.
        [HttpGet]
        public string GetShirts([FromQuery] string? Id)
        {
            return string.IsNullOrEmpty(Id) ? "All the shirts!" : $"Shirt fetched from query: {Id}";
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
