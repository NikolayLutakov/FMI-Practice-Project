namespace QuizSystemWeb.Services.Tests
{
    using System;
    public interface ITestService
    {
        void Create(string title, DateTime startDate, DateTime endDate, TimeSpan duration, string authorId);
    }
}
