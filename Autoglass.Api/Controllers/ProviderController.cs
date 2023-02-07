using Microsoft.AspNetCore.Mvc;

namespace Autoglass.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
