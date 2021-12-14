namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using System;
    public class TestService : ITestService
    {
        private readonly ApplicationDbContext data;

        public TestService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string title, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId)
        {
            var test = new Test
            {
                Name = title,
                StartDate = startDate,
                EndDate = endDate,
                Duration = duration,
                IsActive = false,
                AuthorId = authorId
            };

            data.Tests.Add(test);
            data.SaveChanges();
        }
    }
}
