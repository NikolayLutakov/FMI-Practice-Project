namespace QuizSystemWeb.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Services.Answers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AnswersController:AdministratorController
    {
        private readonly IAnswerService answerService;

        public AnswersController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int questionId,string content,bool IsCorrect)
        {
            answerService.Create(questionId, content, IsCorrect);

            return RedirectToAction("Index","Administrator");
        }

    }
}
