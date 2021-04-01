using core_issue.Authentication;
using core_issue.model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace core_issue.Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser> 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)  
        {  
        }  
  
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder); 
            
            //Rename Identity tables to lowercase
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var currentTableName = builder.Entity(entity.Name).Metadata.GetDefaultTableName();
                builder.Entity(entity.Name).ToTable(currentTableName.ToLower());
            }
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }  
    }
}