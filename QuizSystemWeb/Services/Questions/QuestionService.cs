namespace QuizSystemWeb.Services.Questions
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using QuizSystemWeb.Services.Answers.Models;
    using QuizSystemWeb.Services.Questions.Models;
    using System.Collections.Generic;
    using System.Linq;

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

        public ICollection<QuestionServiceModel> GetAllQuestions(int testId)
        {
            var questions = data.Questions
                .Where(x => x.TestId == testId)
                .Select(x => new QuestionServiceModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    
                })
                .ToList();

            return questions;
        }

        public QuestionDetailsServiceModel GetQuestionById(int questionId)
        {
            var question = data.Questions
                .Where(x => x.Id == questionId)
                .Select(x => new QuestionDetailsServiceModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    Points = x.Points,
                    QuestionType = x.QuestionType,
                    Answers = x.Answers.Select(a => new AnswerDetailsServiceModel{
                        Id = a.Id,
                        Content = a.Content,
                        IsCorrect = a.IsCorrect
                    })
                    .ToList(),
                    TestId = x.TestId
                })
                .FirstOrDefault();

            return question;
        }
    }
}
