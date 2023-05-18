using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Models;

namespace S3Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext context;
        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public User FindByUserName(string userName)
        {
            User user=new User();
            user=context.User.Where(x=>x.login_name.Equals(userName)).FirstOrDefault();
            return user;
        }
    }
}
