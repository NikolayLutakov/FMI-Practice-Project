namespace QuizSystemWeb.Services.Tests.Models
{
    using QuizSystemWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TestServiceDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Duration { get; set; }

        public bool IsActive { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
     = new HashSet<Question>();
    }
}
