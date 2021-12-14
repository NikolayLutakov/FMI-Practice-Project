namespace QuizSystemWeb.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static DataConstants.QuestionType;

    public class QuestionType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeMaxLength)]
        public string TypeName { get; set; }
    }
}
