using ClothZone.Models;

namespace ClothZone.Services
{
    public class UserService: IUserService
    {
        private readonly ECContext context;
        public UserService(ECContext context)
        {
            this.context = context;
        }
        List<User> IUserService.GetUsers()
        {
            return context.Users.ToList();
        }

    }
}
