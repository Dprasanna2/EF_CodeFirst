﻿// <auto-generated />
using CODEFIRST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CODEFIRST.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CODEFIRST.Models.Membership", b =>
                {
                    b.Property<int>("Membership_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Membership_Id"), 1L, 1);

                    b.Property<decimal>("Account_Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Membership_Category_Id")
                        .HasColumnType("int");

                    b.Property<int>("Person_Id")
                        .HasColumnType("int");

                    b.HasKey("Membership_Id");

                    b.HasIndex("Membership_Category_Id");

                    b.HasIndex("Person_Id");

                    b.ToTable("MembershipsRecord");

                    b.HasData(
                        new
                        {
                            Membership_Id = 1,
                            Account_Balance = 1000m,
                            Membership_Category_Id = 2,
                            Person_Id = 1
                        },
                        new
                        {
                            Membership_Id = 2,
                            Account_Balance = 1000m,
                            Membership_Category_Id = 1,
                            Person_Id = 1
                        },
                        new
                        {
                            Membership_Id = 3,
                            Account_Balance = 1000m,
                            Membership_Category_Id = 3,
                            Person_Id = 1
                        });
                });

            modelBuilder.Entity("CODEFIRST.Models.MembershipCategory", b =>
                {
                    b.Property<int>("Membership_Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Membership_Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Membership_Category_Id");

                    b.ToTable("MembershipCategories");

                    b.HasData(
                        new
                        {
                            Membership_Category_Id = 1,
                            Membership_Category_Name = "Silver"
                        },
                        new
                        {
                            Membership_Category_Id = 2,
                            Membership_Category_Name = "Gold"
                        },
                        new
                        {
                            Membership_Category_Id = 3,
                            Membership_Category_Name = "Platinum"
                        },
                        new
                        {
                            Membership_Category_Id = 4,
                            Membership_Category_Name = "Diamond"
                        });
                });

            modelBuilder.Entity("CODEFIRST.Models.PersonDetail", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Person_Id"), 1L, 1);

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person_Id");

                    b.ToTable("PersonDetails");

                    b.HasData(
                        new
                        {
                            Person_Id = 1,
                            EmailId = "prasanna7567@gmail.com",
                            FirstName = "Prasanna",
                            LastName = "Dhamal"
                        });
                });

            modelBuilder.Entity("CODEFIRST.Models.Membership", b =>
                {
                    b.HasOne("CODEFIRST.Models.MembershipCategory", "MembershipCategory")
                        .WithMany()
                        .HasForeignKey("Membership_Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CODEFIRST.Models.PersonDetail", "PersonDetail")
                        .WithMany()
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipCategory");

                    b.Navigation("PersonDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
