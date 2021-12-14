using Microsoft.AspNetCore.Mvc;
using QuizSystemWeb.Services.Tests;
using System;
using System.Globalization;

namespace QuizSystemWeb.Areas.Administrator.Controllers
{
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
            var authorId = "338f72d9-5d40-4f10-9890-fad77ff9f298";
            var start = DateTime.ParseExact(startDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(endDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var dur = TimeSpan.Parse(duration);

            service.Create(title, start, end, dur, authorId);
            return View();
        }
    }
}
