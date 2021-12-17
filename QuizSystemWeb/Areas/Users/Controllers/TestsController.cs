﻿namespace QuizSystemWeb.Areas.Users.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Infrastructure;
    using QuizSystemWeb.Services.Questions;
    using QuizSystemWeb.Services.Tests;
    using System.IO;
    using System.Threading.Tasks;

    public class TestsController : UsersController
    {
        private readonly IQuestionService service;
        private readonly ITestService testService;

        public TestsController(IQuestionService service, ITestService testService)
        {
            this.service = service;
            this.testService = testService;
        }

        public IActionResult Compete(int id)
        {
            var model = service.GetAllTestQuestions(id);
            return View(model);
        }

        [HttpPost]
        public async Task<int> Compete()
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
            {
                 body = await reader.ReadToEndAsync();
            }
            
            int points = testService.SubmitUserAnswers(body, this.User.Id());

            return points;
        }

        public IActionResult Completed()
        {
            var completedTests = this.testService.CompletedTests(this.User.Id());

            return View(completedTests);

        }
    }
}