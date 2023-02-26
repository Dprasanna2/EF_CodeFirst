using Microsoft.EntityFrameworkCore;

namespace CODEFIRST.Models
{
    public static class ModelBuilderExtension
    {
        public static void MembershipCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipCategory>().HasData(
                new MembershipCategory
                {
                    Membership_Category_Id = MembershipCategoryEnum.Silver,
                    Membership_Category_Name = "Silver"
                },
                  new MembershipCategory
                  {
                      Membership_Category_Id = MembershipCategoryEnum.Gold,
                      Membership_Category_Name = "Gold"
                  },
                    new MembershipCategory
                    {
                        Membership_Category_Id = MembershipCategoryEnum.Platinum,
                        Membership_Category_Name = "Platinum"
                    },
                      new MembershipCategory
                      {
                          Membership_Category_Id = MembershipCategoryEnum.Daimond,
                          Membership_Category_Name = "Diamond"
                      }
                );
        }
        public static void PersonDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonDetail>().HasData(
                new PersonDetail
                {
                    Person_Id = 1,
                    FirstName = "Prasanna",
                    LastName = "Dhamal",
                    EmailId = "prasanna7567@gmail.com"
                }
                );
            


        }
        public static void MembershipRecords(this ModelBuilder modelBuilder)
        {
            //  modelBuilder.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Category_Title ON Categories (Title)");
          
            //modelBuilder.Entity<Membership>()
            //   .HasIndex("IX_Membership_PersonId_MembershipCategoryId", IndexOptions.Clustered
            //               , ri => ri.Property(x => x.OrderDataCode)
            //               , ri => ri.Property(x => x.Number));




            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    Membership_Id = 1,
                    Account_Balance = 1000,
                    Person_Id = 1,
                    Membership_Category_Id = MembershipCategoryEnum.Gold

                },
                new Membership
                {
                    Membership_Id = 2,
                    Account_Balance = 1000,
                    Person_Id = 1,
                    Membership_Category_Id = MembershipCategoryEnum.Silver

                },
                new Membership
                {
                    Membership_Id = 3,
                    Account_Balance = 1000,
                    Person_Id = 1,
                    Membership_Category_Id = MembershipCategoryEnum.Platinum
                }
                );
        }
    }
}
