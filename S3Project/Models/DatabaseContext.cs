using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using S3Project.Entities;
using S3Project.Models;

namespace S3Project.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<Visitor_Info> VisitorInfo { get; set; }
        public DbSet<Information> Information { get; set; }

        public DbSet<Data> Data { get; set; }
        public DbSet<User> User { get; set; }
    }
}
