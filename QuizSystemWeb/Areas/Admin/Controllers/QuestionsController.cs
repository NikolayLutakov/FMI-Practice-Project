namespace QuizSystemWeb.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Services.Questions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class QuestionsController:AdministratorController
    {
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        public IActionResult Create(int id)
        {
            ViewBag.TestId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int testId,string content,int points,int questionType)
        {
            questionService.Create(content, points, questionType, testId);

            return RedirectToAction("Index", "Administrator");
        }

        public IActionResult Details(int id)
        {
            var model = questionService.GetQuestionById(id);

            return View(model);
        }

    }
}
