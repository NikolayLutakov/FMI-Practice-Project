using Microsoft.AspNetCore.Mvc;
using QuizSystemWeb.Services.Tests;

namespace QuizSystemWeb.Areas.Users.Controllers
{
    public class HomeController : UsersController
    {
        private readonly ITestService service;

        public HomeController(ITestService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var model = service.GetAllActiveTests();
            return View(model);
        }
    }
}
