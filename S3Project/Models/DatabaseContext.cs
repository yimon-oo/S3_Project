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

        public DbSet<Visitor_Info> VisitorInfo { get; set; } = null!;
        public DbSet<Information> Information { get; set; } = null!;

        public DbSet<Data> Data { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!; 

        //public DbSet<S3Project.Models.VisitorInfoListViewModel>? VisitorInfoList { get; set; }

        //public DbSet<S3Project.Models.LoginViewModel>? LoginViewModel { get; set; }
    }
}
