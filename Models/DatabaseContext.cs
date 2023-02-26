using Microsoft.EntityFrameworkCore;

namespace CODEFIRST.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<MembershipCategory> MembershipCategories { get; set; }
        public DbSet<Membership> MembershipsRecord { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Person_Detail();
        //}
        //protected override void Seed(MyContext context)
        //{
        //    context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Category_Title ON Categories (Title)");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.PersonDetails();
            modelBuilder.MembershipCategory();
            modelBuilder.MembershipRecords();
        }

    }
}
