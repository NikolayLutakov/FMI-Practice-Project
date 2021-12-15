namespace QuizSystemWeb.Services.Answers.Models
{
    public class AnswerDetailsServiceModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

    }
}
