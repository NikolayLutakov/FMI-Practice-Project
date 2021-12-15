namespace QuizSystemWeb.Areas.Admin.Models.Answer
{
    using System.ComponentModel.DataAnnotations;
    using static QuizSystemWeb.Data.DataConstants.Answer;
    public class AnswerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
