namespace QuizSystemWeb.Areas.Admin.Controllers
{
   using Microsoft.AspNetCore.Mvc;
   using QuizSystemWeb.Infrastructure;
   using QuizSystemWeb.Services.Tests;
   using System;
   using System.Globalization;

    public class TestsController : AdministratorController
    {
        private readonly ITestService service;

        public TestsController(ITestService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string startDate, string endDate, string duration)
        {
            var authorId = this.User.Id();
            var start = DateTime.ParseExact(startDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(endDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var dur = TimeSpan.Parse(duration);

            service.Create(title, start, end, dur, authorId);
            return RedirectToAction("Index","Administrator");
        }
    }
}
