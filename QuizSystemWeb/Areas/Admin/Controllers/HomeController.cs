namespace QuizSystemWeb.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController:AdministratorController
    {
        public IActionResult Index()
        {
            return RedirectToAction("All", "Tests");
        }
    }
}
