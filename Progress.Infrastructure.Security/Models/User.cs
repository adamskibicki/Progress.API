namespace Progress.Infrastructure.Security.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}