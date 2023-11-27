using Microsoft.AspNetCore.Mvc;

namespace TweetBook.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("api/v1/")]
        public IActionResult Index()
        {
            return Ok(new { Name = "Test" });
        }
    }
}
