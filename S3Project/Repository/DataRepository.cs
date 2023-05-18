using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Models;

namespace S3Project.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly DatabaseContext context;
        public DataRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(Data data)
        {
            context.Data.Add(data);
            var id = context.SaveChanges();
            return id;
        }
    }
}
