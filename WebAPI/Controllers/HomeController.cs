using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult index()
        {
            return Redirect("~/swagger");
        }
    }
}
