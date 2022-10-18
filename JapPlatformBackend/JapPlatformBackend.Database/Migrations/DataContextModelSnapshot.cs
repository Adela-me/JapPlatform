﻿// <auto-generated />
using System;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JapPlatformBackend.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JapPlatformBackend.Core.Dtos.Admin.GetOverallSuccess", b =>
                {
                    b.Property<double>("OverallSuccessRate")
                        .HasColumnType("float");

                    b.ToTable("GetOverallSuccess", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Dtos.Admin.GetSelectionsSuccess", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SuccessRate")
                        .HasColumnType("float");

                    b.ToTable("GetSelectionsSuccess", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.",
                            Name = "JAP Dev"
                        },
                        new
                        {
                            Id = 2,
                            Description = "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.",
                            Name = "JAP QA"
                        },
                        new
                        {
                            Id = 3,
                            Description = "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.",
                            Name = "JAP DevOps"
                        });
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            Id = 1,
                            ConcurrencyStamp = "2a20171f-e516-4411-b493-50acf2d8b425",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "44aa65a8-7826-4e02-a14f-b0c8be0aac11",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Selection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Selections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8657),
                            ModifiedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8684),
                            Name = "JAP Dev 09/2022",
                            ProgramId = 1,
                            StartDate = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8689),
                            ModifiedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8691),
                            Name = "JAP QA 09/2022",
                            ProgramId = 2,
                            StartDate = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8693),
                            ModifiedAt = new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8694),
                            Name = "JAP DevOps 09/2022",
                            ProgramId = 3,
                            StartDate = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        });
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5216ac0f-6432-42af-910b-590af5143102",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEJDmi/fvWGj86JFpXNvbqxsROXXpBJjscHv2CmSiALHC4akqiKbvt9Hzl7MJ1FV4RA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 6,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 7,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Student", b =>
                {
                    b.HasBaseType("JapPlatformBackend.Core.Entities.User");

                    b.Property<int?>("SelectionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasIndex("SelectionId");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "5c6cc880-d29d-4862-8ba2-b2663a096d13",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEHrswnDsjKD9H2TTpFxr6hmmgWlJze+O44n8XyK+xYF2TxrJ+9qPGWDwQgyfu3nReQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "john",
                            SelectionId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1998, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "083c4f20-c464-4f73-bb73-d433d536b1c4",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEBUeZxH0QLmuSpoQ4irvnpHTxVpKCcBGNqFquQz8i+DxSTEdTkGCdV0oovRF76YnIg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "jane",
                            SelectionId = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1993, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "842d77da-ea0b-434e-85e4-89e0791f2c17",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Jessica",
                            LastName = "Jones",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEJBAqAY/ScjHd2YPdXT+DelIgQBM7HPQYXQKC372dd1VeHjs0ea5XMA5jYrTUWleYA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "jessica",
                            SelectionId = 2,
                            Status = 3
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "adb41fa9-8b3d-489e-b087-5e861afa4042",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEPaaRoQrScm6mc5fJUlxhLkDfHQq78KR1d3TpETXoYBhIfwJ7gxGPbW0nx6pPw4NTg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "bruce",
                            SelectionId = 2,
                            Status = 1
                        },
                        new
                        {
                            Id = 6,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "d24c9a6e-f040-4e8a-9064-8082c065fe11",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Matt",
                            LastName = "Murdock",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEK+JgLwkeNsA+nHudmLmjxGPatnvin0GBtcVOGQiINYErUyDvr/43jvajvIHz0q7eg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "matt",
                            SelectionId = 2,
                            Status = 1
                        },
                        new
                        {
                            Id = 7,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1985, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "21d5e92f-f052-4cc7-96d7-57cebfed6562",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mail@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Tony",
                            LastName = "Stark",
                            LockoutEnabled = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = "AQAAAAEAACcQAAAAEBV+/38YDeEMwaarznrZqB7ZxeVsRHmDoB3GaAohXQghQmfaxyLUN9303Gca2+Q1hw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "tony",
                            SelectionId = 3,
                            Status = 2
                        });
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Comment", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("JapPlatformBackend.Core.Entities.Student", "Student")
                        .WithMany("Comments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Selection", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.Program", "Program")
                        .WithMany("Selections")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.UserRole", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JapPlatformBackend.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Student", b =>
                {
                    b.HasOne("JapPlatformBackend.Core.Entities.Selection", "Selection")
                        .WithMany("Students")
                        .HasForeignKey("SelectionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Program", b =>
                {
                    b.Navigation("Selections");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Selection", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("JapPlatformBackend.Core.Entities.Student", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}