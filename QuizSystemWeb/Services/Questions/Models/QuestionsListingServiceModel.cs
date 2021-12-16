using System.Collections.Generic;

namespace QuizSystemWeb.Services.Questions.Models
{
    public class QuestionsListingServiceModel
    {
        public ICollection<QuestionDetailsServiceModel> QuestionsList { get; set; }
    }
}
