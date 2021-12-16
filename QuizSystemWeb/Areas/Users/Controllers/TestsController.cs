namespace QuizSystemWeb.Areas.Users.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuizSystemWeb.Services.Questions;
    using System.IO;
    using System.Threading.Tasks;

    public class TestsController : UsersController
    {
        private readonly IQuestionService service;

        public TestsController(IQuestionService service)
        {
            this.service = service;
        }

        public IActionResult Compete(int id)
        {
            var model = service.GetAllTestQuestions(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Compete()
        {
            string result;
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync();
                result = body.Result;
                // Do something
            
            }
            ;
            return RedirectToAction("Index", "Home");
        }
    }
}
