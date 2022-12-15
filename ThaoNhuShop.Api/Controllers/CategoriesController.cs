using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("categories")]
    [Authorize]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Array.Empty<string>());
        }
    }
}