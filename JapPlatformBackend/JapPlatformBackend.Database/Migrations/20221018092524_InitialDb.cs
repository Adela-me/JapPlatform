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
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2a20171f-e516-4411-b493-50acf2d8b425", "Admin", "ADMIN" },
                    { 2, "44aa65a8-7826-4e02-a14f-b0c8be0aac11", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, null, "5216ac0f-6432-42af-910b-590af5143102", "User", "mail@mail.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEJDmi/fvWGj86JFpXNvbqxsROXXpBJjscHv2CmSiALHC4akqiKbvt9Hzl7MJ1FV4RA==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", "JAP Dev" },
                    { 2, "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", "JAP QA" },
                    { 3, "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities.", "JAP DevOps" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "ProgramId", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8657), new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8684), "JAP Dev 09/2022", 1, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8689), new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8691), "JAP QA 09/2022", 2, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 10, 18, 11, 25, 24, 623, DateTimeKind.Local).AddTicks(8694), "JAP DevOps 09/2022", 3, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SelectionId", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5c6cc880-d29d-4862-8ba2-b2663a096d13", "Student", "mail@mail.com", false, "John", "Doe", false, null, null, null, "AQAAAAEAACcQAAAAEHrswnDsjKD9H2TTpFxr6hmmgWlJze+O44n8XyK+xYF2TxrJ+9qPGWDwQgyfu3nReQ==", null, false, null, 1, 0, false, "john" },
                    { 3, 0, new DateTime(1998, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "083c4f20-c464-4f73-bb73-d433d536b1c4", "Student", "mail@mail.com", false, "Jane", "Doe", false, null, null, null, "AQAAAAEAACcQAAAAEBUeZxH0QLmuSpoQ4irvnpHTxVpKCcBGNqFquQz8i+DxSTEdTkGCdV0oovRF76YnIg==", null, false, null, 1, 1, false, "jane" },
                    { 4, 0, new DateTime(1993, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "842d77da-ea0b-434e-85e4-89e0791f2c17", "Student", "mail@mail.com", false, "Jessica", "Jones", false, null, null, null, "AQAAAAEAACcQAAAAEJBAqAY/ScjHd2YPdXT+DelIgQBM7HPQYXQKC372dd1VeHjs0ea5XMA5jYrTUWleYA==", null, false, null, 2, 3, false, "jessica" },
                    { 5, 0, new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "adb41fa9-8b3d-489e-b087-5e861afa4042", "Student", "mail@mail.com", false, "Bruce", "Wayne", false, null, null, null, "AQAAAAEAACcQAAAAEPaaRoQrScm6mc5fJUlxhLkDfHQq78KR1d3TpETXoYBhIfwJ7gxGPbW0nx6pPw4NTg==", null, false, null, 2, 1, false, "bruce" },
                    { 6, 0, new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "d24c9a6e-f040-4e8a-9064-8082c065fe11", "Student", "mail@mail.com", false, "Matt", "Murdock", false, null, null, null, "AQAAAAEAACcQAAAAEK+JgLwkeNsA+nHudmLmjxGPatnvin0GBtcVOGQiINYErUyDvr/43jvajvIHz0q7eg==", null, false, null, 2, 1, false, "matt" },
                    { 7, 0, new DateTime(1985, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "21d5e92f-f052-4cc7-96d7-57cebfed6562", "Student", "mail@mail.com", false, "Tony", "Stark", false, null, null, null, "AQAAAAEAACcQAAAAEBV+/38YDeEMwaarznrZqB7ZxeVsRHmDoB3GaAohXQghQmfaxyLUN9303Gca2+Q1hw==", null, false, null, 3, 2, false, "tony" }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
