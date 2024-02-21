﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Entities.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Atlas Koleji olarak 2009 yılında başladığımız yolculuğumuzda, ortaokul ve lise öğrencilerimizin başarıya ulaşmasını hedefliyor aynı zamanda hayalindeki lise ve üniversiteleri kazanmaları için elimizden geleni yapıyoruz. Okulda yapılan eğitimin yanı sıra web sitemiz sayesinde konuları pekiştirebilme ve birebir öğretmenle iletişime geçme imkanına sahip olabilecekler. Bu güne kadar mezunlarımızın çoğuna Türkiye'de oldukça ünlü okulları kazanabilmelerine vesile olduk. Hemen siz de iletişime geçin ve uygun fiyatlarla kolejimize kaydolarak hayallerinize ulaşın.",
                            Title = "Çocuğunuz İçin En İyi Seçim Biziz"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupportEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityLayer.Entities.Announcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("EntityLayer.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                            ConcurrencyStamp = "10ec64ac-1437-40db-8fe2-8e2983803275",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                            ConcurrencyStamp = "7bd847f2-1964-4914-b882-af2920258b87",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                            ConcurrencyStamp = "b9041179-1b39-4aa1-a7c5-918479bb6082",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                            ConcurrencyStamp = "02a15cd1-873d-491c-a0eb-0f8b11d0f3c5",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentNo")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3efd2b08-1f61-4e76-8ae9-9390708a2543",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Admin",
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEDTFow+Bxlt5VFHQ3s+YQl86tBZBd4/t0RTYVoDW08CbX2qkMyHN7cIE1tvi/3OInA==",
                            PhoneNumber = "+901111111111",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "582f164a-bc83-426f-8b38-367431c25e14",
                            Surname = "Admin",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c53ad87-c020-4e4d-9521-23e1a46b7cd1",
                            Email = "ogretmen@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Öğretmen",
                            NormalizedEmail = "OGRETMEN@GMAIL.COM",
                            NormalizedUserName = "OGRETMEN",
                            PasswordHash = "AQAAAAIAAYagAAAAEKLAMiZms5fSZNoPhSbL5t5Y3m9DiWxOhMquEgHVxu5VlAe0w8Rpn+QF+JG09XOCeA==",
                            PhoneNumber = "+902222222222",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "c66fed50-eaf6-4f86-8195-101d5aec6d95",
                            Surname = "Öğretmen",
                            TwoFactorEnabled = false,
                            UserName = "ogretmen"
                        },
                        new
                        {
                            Id = new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1047a1d2-20ae-4044-964d-3324a489f423",
                            Email = "ogrenci@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Öğrenci",
                            NormalizedEmail = "OGRENCİ@GMAIL.COM",
                            NormalizedUserName = "OGRENCİ",
                            PasswordHash = "AQAAAAIAAYagAAAAEAmZmeHc3aRlrDEMwkG4Da157K6w/tbkkUeiuCQCOu5R18iAyEX7T1YjnL88DMMA3w==",
                            PhoneNumber = "+903333333333",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "b18a7548-9e61-4817-8b52-ed126df0b5b7",
                            Surname = "Öğrenci",
                            TwoFactorEnabled = false,
                            UserName = "ogrenci"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "9. Sınıf"
                        },
                        new
                        {
                            Id = 2,
                            Name = "10. Sınıf"
                        },
                        new
                        {
                            Id = 3,
                            Name = "11. Sınıf"
                        },
                        new
                        {
                            Id = 4,
                            Name = "12. Sınıf"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LessonCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonCredit")
                        .HasColumnType("int");

                    b.Property<Guid?>("LessonDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LessonVideoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("LessonDocumentId");

                    b.HasIndex("LessonVideoId");

                    b.HasIndex("UserId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84872d3c-20fb-4b81-b224-4454568269e2"),
                            GradeId = 1,
                            IsDeleted = false,
                            LessonCode = "B100",
                            LessonCredit = 2,
                            LessonName = "Bilgisayar Sistemleri"
                        },
                        new
                        {
                            Id = new Guid("c43a22c4-6c59-4aaa-8efe-6d627098f4c8"),
                            GradeId = 2,
                            IsDeleted = false,
                            LessonCode = "M102",
                            LessonCredit = 5,
                            LessonName = "Matematik"
                        },
                        new
                        {
                            Id = new Guid("21357f73-d39d-40cd-86f2-d5c59a32e210"),
                            GradeId = 3,
                            IsDeleted = false,
                            LessonCode = "F205",
                            LessonCredit = 3,
                            LessonName = "Fizik"
                        },
                        new
                        {
                            Id = new Guid("9599c5ab-4a16-4688-af7b-79dd0a04ef9b"),
                            GradeId = 4,
                            IsDeleted = false,
                            LessonCode = "B101",
                            LessonCredit = 3,
                            LessonName = "Biyoloji"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LessonDocuments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e3d399ad-12ff-455a-9089-f2eb0e7fcafd"),
                            DocumentPath = "test",
                            IsDeleted = false,
                            Title = "Deneme"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonScore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PerformanceScore")
                        .HasColumnType("float");

                    b.Property<double>("Score1")
                        .HasColumnType("float");

                    b.Property<double>("Score2")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("LessonScores");
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonVideo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LessonVideos");
                });

            modelBuilder.Entity("EntityLayer.Entities.NewsLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsLetters");
                });

            modelBuilder.Entity("EntityLayer.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Entities.Announcement", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppUser", "User")
                        .WithMany("Announcements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Entities.AppUser", b =>
                {
                    b.HasOne("EntityLayer.Entities.Grade", "Grade")
                        .WithMany("Users")
                        .HasForeignKey("GradeId");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("EntityLayer.Entities.Lesson", b =>
                {
                    b.HasOne("EntityLayer.Entities.Grade", "Grade")
                        .WithMany("Lessons")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.LessonDocument", "LessonDocument")
                        .WithMany("Lessons")
                        .HasForeignKey("LessonDocumentId");

                    b.HasOne("EntityLayer.Entities.LessonVideo", "LessonVideo")
                        .WithMany("Lessons")
                        .HasForeignKey("LessonVideoId");

                    b.HasOne("EntityLayer.Entities.AppUser", "User")
                        .WithMany("Lessons")
                        .HasForeignKey("UserId");

                    b.Navigation("Grade");

                    b.Navigation("LessonDocument");

                    b.Navigation("LessonVideo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonScore", b =>
                {
                    b.HasOne("EntityLayer.Entities.Lesson", "Lesson")
                        .WithMany("LessonScores")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.AppUser", "User")
                        .WithMany("LessonScores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EntityLayer.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Entities.AppUser", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("LessonScores");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("EntityLayer.Entities.Grade", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EntityLayer.Entities.Lesson", b =>
                {
                    b.Navigation("LessonScores");
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonDocument", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("EntityLayer.Entities.LessonVideo", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
