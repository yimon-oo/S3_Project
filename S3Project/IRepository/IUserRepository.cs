using S3Project.Entities;

namespace S3Project.IRepository
{
    public interface IUserRepository
    {
        User FindByUserName(string userName);
    }
}
