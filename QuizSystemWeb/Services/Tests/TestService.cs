namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using QuizSystemWeb.Services.Questions.Models;
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

        public bool ChangeVisibility(int id)
        {
            var test = data.Tests.FirstOrDefault(x => x.Id == id);

            if (test==null)
            {
                return false;
            }

            test.IsActive= !test.IsActive;

            data.Tests.Update(test);

            data.SaveChanges();

            return true;
        }

        public bool Create(string name, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId)
        {
            if (startDate.CompareTo(endDate) != -1)
            {
                return false;
            }

            var test = new Test
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Duration = duration,
                IsActive = false,
                AuthorId = authorId
            };

            data.Tests.Add(test);
            data.SaveChanges();

            return true;
        }

        public TestServiceDetailsModel Details(int id)
        {
            var test = data.Tests
                .Select(x => new TestServiceDetailsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate.ToString("MM/dd/yyyy"),
                    EndDate = x.EndDate.ToString("MM/dd/yyyy"),
                    Duration = x.Duration.ToString(),
                    IsActive = x.IsActive,
                    AuthorId = x.AuthorId,
                    Author = x.Author,
                    Questions = x.Questions.Select(q => new QuestionServiceModel
                    {
                        Id = q.Id,
                        Content = q.Content
                    })
                    .ToList()
                })
                .FirstOrDefault(x => x.Id == id);

            
            return test;
        }

        public bool Edit(int id,string name, DateTime startDate, DateTime endDate, TimeSpan duration)
        {
            var test = data.Tests.FirstOrDefault(x => x.Id == id);

            if (test == null || startDate.CompareTo(endDate) != -1)
            {
                return false;
            }

            test.Name = name;
            test.StartDate = startDate;
            test.EndDate = endDate;
            test.Duration = duration;

            data.Update(test);

            data.SaveChanges();

            return true;
        }

        public IEnumerable<TestServiceModel> GetAllTests()
        {
            var allTests = data.Tests.Select(x => new TestServiceModel
            {
                Id = x.Id,
                Name = x.Name,
            })
              .ToList();

            return allTests;
        }
    }
}
