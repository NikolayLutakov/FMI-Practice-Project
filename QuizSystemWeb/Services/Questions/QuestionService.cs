namespace QuizSystemWeb.Services.Questions
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using QuizSystemWeb.Services.Answers;
    using QuizSystemWeb.Services.Answers.Models;
    using QuizSystemWeb.Services.Questions.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext data;
        private readonly IAnswerService answerService;

        public QuestionService(ApplicationDbContext data, IAnswerService answerService)
        {
            this.data = data;
            this.answerService = answerService;
        }

        public bool Create(string content, int points, int questionTypeId, int testId)
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

            return true;

        }

        public bool Edit(int questionId, string content, int questionType,int points)
        {
            var question = data.Questions.Where(x => x.Id == questionId).FirstOrDefault();
          
            if(question.QuestionTypeId != questionType && questionType == 2)
            {
                answerService.Delete(questionId);
            }

            var IsQuestionTypeValid = data.QuestionsTypes
                .Select(x => x.Id)
                .ToList()
                .Contains(questionType);

            if (!IsQuestionTypeValid)
            {
                return false;
            }


            question.Content = content;
            question.QuestionTypeId = questionType;
            question.Points = points;



            data.Update(question);
            data.SaveChanges();

            return true;


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
                    QuestionType = x.QuestionType.TypeName,
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

        public ICollection<QuestionTypesServiceModel> GetQuestionTypes()
        => this.data.QuestionsTypes.Select(x => new QuestionTypesServiceModel
        {
            Id = x.Id,
            Name = x.TypeName
        }).ToList();
            
    }
}
