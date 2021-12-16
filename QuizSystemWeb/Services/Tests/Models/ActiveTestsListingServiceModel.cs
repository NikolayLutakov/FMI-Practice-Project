namespace QuizSystemWeb.Services.Tests.Models
{
    public class ActiveTestsListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Duration { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDateInValidRange { get; set; }
    }
}
