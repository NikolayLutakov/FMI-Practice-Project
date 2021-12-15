namespace QuizSystemWeb.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Areas.Admin.Models.Answer;
    using QuizSystemWeb.Services.Answers;

    public class AnswersController : AdministratorController
    {
        private readonly IAnswerService answerService;

        public AnswersController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        public IActionResult Create(int id)
        {
            ViewBag.QuestionId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnswerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var questionId = model.QuestionId;
            var content = model.Content;
            var isCorrect = model.IsCorrect;

            if (answerService.Create(questionId, content, isCorrect) != "OK")
            {
                return BadRequest();
            }
           
            return RedirectToAction("Details", "Questions", new { Id = questionId });
        }

        public IActionResult Edit(int id)
        {
            var answer = answerService.GetById(id);
            var model = new AnswerFormViewModel
            {
                Id = answer.Id,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AnswerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var answerId = model.Id;
            var content = model.Content;
            var isCorrect = model.IsCorrect;

            if (answerService.Edit(answerId, content, isCorrect) != "OK")
            {
                return BadRequest();
            }
            ;
            return RedirectToAction("Details", "Questions", new { id = model.QuestionId });
        }

    }
}
