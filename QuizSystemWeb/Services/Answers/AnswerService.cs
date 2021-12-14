namespace QuizSystemWeb.Services.Answers
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext data;

        public AnswerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(int questionId, string content, bool IsCorrect)
        {
            var answer = new Answer
            {
                QuestionId = questionId,
                Content = content,
                IsCorrect = IsCorrect
            };

            data.Answers.Add(answer);

            data.SaveChanges();
        }
    }
}

