using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/shirts")]
    public class ShirtsController: ControllerBase
    {
        // Query params means you do not use separate routes. You utilize existing ones.
        // Here this is a generic route.
        [HttpGet]
        public string GetShirts([FromQuery] string? Id)
        {
            return string.IsNullOrEmpty(Id) ? "All the shirts!" : $"Shirt fetched from query: {Id}";
        }

        [HttpGet("{Id}")]
        public string GetSpecificShirt([FromRoute] int Id, [FromQuery] string? color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                return $"route param: {Id} | queryParam: {color}";
            }

            return $"Route param: ${Id}";
        }
        
        [HttpPost]
        public string CreateSpecificShirt()
        {
            return "Creating Shirt";
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
