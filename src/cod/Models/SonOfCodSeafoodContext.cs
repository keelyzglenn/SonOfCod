using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cod.Models
{
    public class SonOfCodSeafoodContext : IdentityDbContext<ApplicationUser>
    {
        public SonOfCodSeafoodContext()
        {
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SonOfCodSeafood;integrated security=True");
        }

        public SonOfCodSeafoodContext(DbContextOptions<SonOfCodSeafoodContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}