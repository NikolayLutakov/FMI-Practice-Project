namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using QuizSystemWeb.Services.Tests.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public TestServiceDetailsModel Details(int id)
        {
            var test = data.Tests
                .Select(x => new TestServiceDetailsModel
              {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate.ToString("d"),
                EndDate = x.EndDate.ToString("d"),
                Duration = x.Duration.ToString(),
                IsActive = x.IsActive,
                AuthorId = x.AuthorId,
                Author = x.Author,
                Questions = x.Questions
                })
                .FirstOrDefault(x => x.Id == id);

            //TODO:Questions model

            return test;
        }

        public IEnumerable<TestServiceModel> GetAllTests()
        {
            var allTests = data.Tests.Select(x => new TestServiceModel
            {
                Id=x.Id,
                Name = x.Name,
            })
              .ToList();

            return allTests;
        }
    }
}
