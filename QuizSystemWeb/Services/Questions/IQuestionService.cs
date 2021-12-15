namespace QuizSystemWeb.Services.Questions
{
    using QuizSystemWeb.Services.Questions.Models;
    using System.Collections.Generic;
   
    public interface IQuestionService
    {
        void Create(string content, int points, int questionTypeId, int testId);

        ICollection<QuestionServiceModel> GetAllQuestions(int testId);

        QuestionDetailsServiceModel GetQuestionById(int questionId);

    }
}
