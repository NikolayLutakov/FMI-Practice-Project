namespace QuizSystemWeb.Services.Questions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IQuestionService
    {
        void Create(string content, int points, int questionTypeId, int testId);
        
    }
}
