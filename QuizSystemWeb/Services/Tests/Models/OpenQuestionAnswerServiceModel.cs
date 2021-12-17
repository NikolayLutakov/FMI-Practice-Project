namespace QuizSystemWeb.Services.Tests.Models
{
    public class OpenQuestionAnswerServiceModel
    {
        public string QuestionContent { get; set; }

        public int QuestionId { get; set; }

        public string AnswerText { get; set; }

        public int PointsForAnswer { get; set; }

        public int MaxPoints { get; set; }
    }
}
