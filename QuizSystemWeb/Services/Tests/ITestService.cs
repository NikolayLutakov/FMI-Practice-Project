namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Services.Tests.Models;
    using System;
    using System.Collections.Generic;

    public interface ITestService
    {
        void SubmitUserAnswers(string input,string userId);

        bool Create(string name, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId);

        bool Edit(int id,string name, DateTime startDate, DateTime endDate, TimeSpan duration);

        bool ChangeVisibility(int id);

        IEnumerable<TestServiceModel> CompletedTests(string userId);

        IEnumerable<TestServiceModel> GetAllTests();

        IEnumerable<ActiveTestsListingServiceModel> GetAllActiveTests(string userId);

        TestServiceDetailsModel Details(int id);
    }
}
