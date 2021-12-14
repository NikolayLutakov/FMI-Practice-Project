namespace QuizSystemWeb.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static QuizSystemWeb.Areas.Administrator.AdministratorConstants;

    [Area(AdministratorAreaName)]
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
