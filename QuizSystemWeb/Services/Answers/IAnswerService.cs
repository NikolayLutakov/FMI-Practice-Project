namespace QuizSystemWeb.Services.Answers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAnswerService
    {
        void Create(int questionId, string content, bool IsCorrect);
    }
}
