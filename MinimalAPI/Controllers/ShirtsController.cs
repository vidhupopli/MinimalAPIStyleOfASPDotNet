using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/shirts")]
    public class ShirtsController: ControllerBase
    {
        [HttpGet]
        public string GetAllShirts()
        {
            return "All the shirts!";
        }
        
        [HttpPost]
        public string CreateSpecificShirt()
        {
            return "Creating Shirt";
        }

        [HttpGet("{Id}")] // In case you do not want to use Route attribute.
        public string GetSpecificShirt(int Id)
        {
            return $"Specific Shirt: {Id}";
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
