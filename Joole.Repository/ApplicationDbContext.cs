using System;
using System.Collections.Generic;
using System.Data.Entity;
using Joole.Dal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repository
{
    public class ApplicationDbContext : DbContext
    {
        /*public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }*/
        public DbSet<User> Users { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());
        }*/
    }
}
