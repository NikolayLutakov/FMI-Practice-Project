namespace QuizSystemWeb.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
