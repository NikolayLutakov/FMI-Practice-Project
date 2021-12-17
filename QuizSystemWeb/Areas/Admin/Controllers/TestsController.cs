namespace QuizSystemWeb.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Areas.Admin.Models.Test;
    using QuizSystemWeb.Infrastructure;
    using QuizSystemWeb.Services.Tests;
    using QuizSystemWeb.Services.Tests.Models;
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
        public IActionResult Create(TestFormModel model)
        {
            var authorId = this.User.Id();

            service.Create(model.Name, model.StartDate, model.EndDate, model.Duration, authorId);
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var allTests = this.service.GetAllTests();

            return View(allTests);
        }

        public IActionResult Details(int id)
        {
            var test = this.service.Details(id);

            return View(test);

        }

        public IActionResult Edit(int id)
        {
            var test = this.service.Details(id);

            var testDto = new TestFormModel
            {
                Id = test.Id,
                Name = test.Name,
                StartDate = DateTime.ParseExact(test.StartDate, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact(test.EndDate, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                Duration = TimeSpan.Parse(test.Duration),
            };


            return View(testDto);
        }


        [HttpPost]
        public IActionResult Edit(TestFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!(service.Edit(model.Id, model.Name, model.StartDate, model.EndDate, model.Duration)))
            {
                return BadRequest();
            }
            ;
            return RedirectToAction("Details", "Tests", new { id = model.Id });

        }

        public IActionResult ChangeVisibility(int id)
        {
            if (!this.service.ChangeVisibility(id))
            {
                return NotFound();
            }


            return RedirectToAction("All");

        }

        public IActionResult EvaluateTests()
        {
            var model = service.GetAllUnvaluatedTests();
            return View(model);
        }

        public IActionResult CheckOpenedQuestions(string userId, int testId)
        {
            var model = service.GetOpenedAnswersForSolvedTest(userId, testId);
            return View(model);
        }
    }
}
