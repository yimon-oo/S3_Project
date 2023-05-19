using Microsoft.EntityFrameworkCore;
using S3Project.Entities;
using S3Project.Models;

namespace S3Project.IRepository
{
    public class VisitorInfoRepository : IVisitorInfoRepository
    {
        private readonly DatabaseContext context;

        public VisitorInfoRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int CreateOrUpdate(Visitor_Info VisitorInfo)
        {
            if (VisitorInfo.id > 0)
            {
                context.VisitorInfo.Attach(VisitorInfo);
                context.Entry(VisitorInfo).State = EntityState.Modified;
                context.VisitorInfo.Update(VisitorInfo);
            }
            else
            {
                context.VisitorInfo.Add(VisitorInfo);
            }
            var result = context.SaveChanges();
            //return VisitorInfo.id;
            return result;
        }

        public int Delete(int id)
        {
            var data = context.VisitorInfo.Where(x => x.id == id).FirstOrDefault();
            context.VisitorInfo.Remove(data);
            var result = context.SaveChanges();
            return result;
        }

        public Visitor_Info Get(int id)
        {
            Visitor_Info result = new Visitor_Info();
            result = context.VisitorInfo.Find(id);
            return result;
        }

        public List<Visitor_Info> GetAll()
        {
            List<Visitor_Info> list = context.VisitorInfo.ToList();
            return list;
        }
    }
}
