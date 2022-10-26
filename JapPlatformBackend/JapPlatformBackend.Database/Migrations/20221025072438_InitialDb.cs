using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JapPlatformBackend.Database.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrograms",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrograms", x => new { x.ProgramId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemPrograms_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPrograms_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    SelectionId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemProgramStudents",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Progress = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ProgressStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProgramStudents", x => new { x.ItemId, x.ProgramId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ItemProgramStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemProgramStudents_ItemPrograms_ProgramId_ItemId",
                        columns: x => new { x.ProgramId, x.ItemId },
                        principalTable: "ItemPrograms",
                        principalColumns: new[] { "ProgramId", "ItemId" });
                    table.ForeignKey(
                        name: "FK_ItemProgramStudents_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemProgramStudents_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "4752f5aa-0d3e-474b-ac5a-1d24372f8a04", "Admin", "ADMIN" },
                    { 2, "ff0b6b9a-6493-4ed5-af1b-bb9589e93b6f", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, null, "250f6205-adbe-4262-8e3e-d5353e89a64e", "User", "mail@mail.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAELvMyjavT4M+CCtkEjGzESH86linmU5qMaEYk/B4Tf0XB1mVcEz70Gy9wZ4wfnLCFA==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "Description", "Discriminator", "ModifiedAt", "Name", "Urls", "WorkHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4043), "Description of the React Course", "Lecture", new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4047), "React Course", "udemy.com", 20 },
                    { 2, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4050), ".Net Course Description", "Lecture", new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4052), ".Net Course", "udemy.com", 30 },
                    { 3, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4054), "Course Description", "Lecture", new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4056), "Postman Course", "udemy.com", 10 },
                    { 4, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4058), "Course Description", "Lecture", new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4060), "xUnit Course", "udemy.com", 10 },
                    { 5, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4062), "Course Description", "Lecture", new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(4063), "Docker Course", "udemy.com", 20 }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8017), "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8043), "JAP Dev" },
                    { 2, new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8048), "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8050), "JAP QA" },
                    { 3, new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8052), "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", new DateTime(2022, 10, 25, 9, 24, 38, 436, DateTimeKind.Local).AddTicks(8053), "JAP DevOps" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ItemPrograms",
                columns: new[] { "ItemId", "ProgramId", "OrderNumber" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 1 },
                    { 5, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "CreatedAt", "EndDate", "ModifiedAt", "Name", "ProgramId", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3865), new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3885), "JAP Dev 09/2022", 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3891), new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3892), "JAP QA 09/2022", 2, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3895), new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 9, 24, 38, 476, DateTimeKind.Local).AddTicks(3897), "JAP DevOps 09/2022", 3, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SelectionId", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "6493cb67-0cbd-4863-b8bf-6f0921c42df0", "Student", "mail@mail.com", false, "John", "Doe", false, null, null, null, "AQAAAAEAACcQAAAAEP1N3yvMRs1cu6LaP4g9dyAbYhuX5h2SjyB+5jatTuxLhFxTEBw2R8Z03IJPCO66vg==", null, false, null, 1, 0, false, "john" },
                    { 3, 0, new DateTime(1998, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "37516b60-7d12-430e-ac66-0883aaf95990", "Student", "mail@mail.com", false, "Jane", "Doe", false, null, null, null, "AQAAAAEAACcQAAAAEIxk0SHnZgmoV2Fuh9KWxLYFmSneKLXcRs2ZGbLUOHyEQDGbKhb6nmc5QWS8yFbGbg==", null, false, null, 1, 1, false, "jane" },
                    { 4, 0, new DateTime(1993, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "03b0b1ed-9ede-4c68-8a83-d0fa9d89e351", "Student", "mail@mail.com", false, "Jessica", "Jones", false, null, null, null, "AQAAAAEAACcQAAAAECZqpwaIatluYCDXuIbIbSYe7ZO2gixMno1Ei6SUMU3j2diTW5NzkR0jyqe2nJl/ZA==", null, false, null, 2, 3, false, "jessica" },
                    { 5, 0, new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "0722abd1-5572-41c1-aee8-0c9351e3ea5d", "Student", "mail@mail.com", false, "Bruce", "Wayne", false, null, null, null, "AQAAAAEAACcQAAAAEGWp3D2ENY6sl7P2dcikAmxDScnpaY9C5W3p8V9QbYx8h/A6zDW4zBhEf/OLHNIt1Q==", null, false, null, 2, 1, false, "bruce" },
                    { 6, 0, new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "0c1401df-0ef8-45c3-9e95-bf9547d74b6f", "Student", "mail@mail.com", false, "Matt", "Murdock", false, null, null, null, "AQAAAAEAACcQAAAAEDedNaVoXcgUpbf39cjrzkeSEYPYNkBTuWjbbdkhJedHhsZ2hQBL6i51y5BYc9RROw==", null, false, null, 2, 1, false, "matt" },
                    { 7, 0, new DateTime(1985, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2d890114-e79f-4762-adc0-89ac19729098", "Student", "mail@mail.com", false, "Tony", "Stark", false, null, null, null, "AQAAAAEAACcQAAAAEK4cJDxjG5H5Ag0c3Chnv6IYTOfDNyuu0MZGfFj2pbjIw+bzIof1EKL4xe0ZecayYg==", null, false, null, 3, 2, false, "tony" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SelectionId",
                table: "AspNetUsers",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrograms_ItemId",
                table: "ItemPrograms",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProgramStudents_ProgramId_ItemId",
                table: "ItemProgramStudents",
                columns: new[] { "ProgramId", "ItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemProgramStudents_StudentId",
                table: "ItemProgramStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ProgramId",
                table: "Selections",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ItemProgramStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemPrograms");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
