namespace QuizSystemWeb.Services.Questions
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext data;

        public QuestionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string content, int points, int questionTypeId, int testId)
        {
            var question = new Question
            {
                Content = content,
                Points = points,
                QuestionTypeId = questionTypeId,
                TestId = testId
            };

            this.data.Questions.Add(question);

            this.data.SaveChanges();

        }
    }
}
