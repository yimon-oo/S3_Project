using S3Project.Entities;

namespace S3Project.IRepository
{
    public interface IVisitorInfoRepository
    {
        List<Visitor_Info> GetAll();
        int CreateOrUpdate(Visitor_Info VisitorInfo);
        Visitor_Info Get(int id);
        int Delete(int id);
    }
}
