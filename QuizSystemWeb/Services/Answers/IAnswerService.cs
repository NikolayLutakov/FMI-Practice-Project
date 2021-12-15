namespace QuizSystemWeb.Services.Answers
{
    using QuizSystemWeb.Services.Answers.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAnswerService
    {
        string Create(int questionId, string content, bool IsCorrect);

        string Edit(int answerId, string content, bool IsCorrect);

        AnswerDetailsServiceModel GetById(int id);
    }
}
