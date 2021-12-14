namespace QuizSystemWeb.Services.Tests
{
    using QuizSystemWeb.Services.Tests.Models;
    using System;
    using System.Collections.Generic;

    public interface ITestService
    {
        void Create(string title, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId);

        IEnumerable<TestServiceModel> GetAllTests();

        TestServiceDetailsModel Details(int id);
    }
}
