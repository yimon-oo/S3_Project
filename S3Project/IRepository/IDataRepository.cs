using S3Project.Entities;

namespace S3Project.IRepository
{
    public interface IDataRepository
    {
        int Create(Data data);
    }
}
