using Progress.Infrastructure.Security.Models;

namespace Progress.Infrastructure.Security
{
    public class StaticUserList
    {
        public static List<User> Users()
        {
            List<User> list = new List<User>();

            User u = new User()
            {
                Email = "stefan@gmail.com",
                FirstName = "Stefan",
                LastName = "Karolos",
                Id = Guid.NewGuid(),
                UserName = "stefos"
            };

            User u2 = new User()
            {
                Email = "eve@gmail.com",
                FirstName = "Ewa",
                LastName = "Zakurka",
                Id = Guid.NewGuid(),
                UserName = "eve"
            };

            list.Add(u); list.Add(u2);

            return list;
        }
    }
}