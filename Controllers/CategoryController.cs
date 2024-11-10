using Microsoft.AspNetCore.Mvc;

namespace CNLTHD.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet("getCategories")]
        public async Task<IActionResult> getCategories([FromQuery] int page = 1, [FromQuery] int limit = 12)
        {
            return Ok("result");
        }
    }
}
