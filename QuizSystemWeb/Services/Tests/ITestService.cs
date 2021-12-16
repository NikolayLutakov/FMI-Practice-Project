namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Services.Tests.Models;
    using System;
    using System.Collections.Generic;

    public interface ITestService
    {
        bool Create(string name, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId);

        bool Edit(int id,string name, DateTime startDate, DateTime endDate, TimeSpan duration);

        bool ChangeVisibility(int id);

        IEnumerable<TestServiceModel> GetAllTests();

        IEnumerable<ActiveTestsListingServiceModel> GetAllActiveTests();

        TestServiceDetailsModel Details(int id);
    }
}
