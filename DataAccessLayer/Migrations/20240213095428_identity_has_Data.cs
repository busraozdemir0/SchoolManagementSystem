using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class identityhasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("71e8407a-13ae-4b9e-9666-d288f5a603d4"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5fb550f9-a9c6-4c85-9042-a115628e5417"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("68a72de0-8c59-44a3-97f2-78361b547c73"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9bb3e61e-8bf6-4653-a79a-30c72fe2f0b7"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9f0e2f3a-6662-4713-8716-30c7a00560a7"));

            migrationBuilder.AlterColumn<string>(
                name: "UserAbout",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"), "e83c80f0-bf80-4c7f-9778-82ce74ca481e", "Student", "STUDENT" },
                    { new Guid("23420044-c9ae-462e-8317-88db8c734de1"), "1d5f305b-69fd-45a5-9de2-7a4b957672c6", "Teacher", "TEACHER" },
                    { new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"), "e528f92e-b56c-41c2-94a2-a1fbac603ecd", "User", "USER" },
                    { new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"), "89024944-2914-483f-bfe8-dde691035710", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "GradeID", "ImagePath", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNo", "Surname", "TwoFactorEnabled", "UserAbout", "UserName" },
                values: new object[,]
                {
                    { new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"), 0, "6e8db8df-82b0-4d50-96d8-1a6194383dcd", "ogretmen@gmail.com", true, null, null, null, false, null, "Öğretmen", "OGRETMEN@GMAIL.COM", "OGRETMEN", "AQAAAAIAAYagAAAAEGC7YIrkIQdIOHIPW7IJ5jDoE+ZGX6BkwCXV22ubWCtt/NrSuoIY/7XL8pwnryFxnw==", "+902222222222", true, "d466cb1b-4435-46ac-9a8c-74cc004b08f8", null, "Öğretmen", false, null, "ogretmen" },
                    { new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"), 0, "bdbebaeb-e346-4f27-9b81-f3a57c4cc096", "admin@gmail.com", true, null, null, null, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEgnkEnA2Naz5DqYQY9uU9mK+PrtnRzpFQ36RiM3W8HUWjKoyj73R+Qr5G6Ith00gw==", "+901111111111", true, "f1357844-3e1f-46ae-a4fa-0ce47953ccbf", null, "Admin", false, null, "admin" },
                    { new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"), 0, "38b14f87-e512-4cd1-8a98-d37adfe38ba8", "ogrenci@gmail.com", true, null, null, null, false, null, "Öğrenci", "OGRENCİ@GMAIL.COM", "OGRENCİ", "AQAAAAIAAYagAAAAEFneWvHeEPtIM38I0+Fws6CjP8m0y/5RLNWN+qHVVtGMPmkmWTqsLmg9rShauY66zw==", "+903333333333", true, "17602b8b-31d4-47e5-9f27-b1edb680450d", null, "Öğrenci", false, null, "ogrenci" }
                });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("c9bc945e-4587-436e-81dd-f5366d7d3ddc"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("99e4216a-32ec-4c51-b5ce-900a7b30710a"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("9e270e61-2867-450b-8aa0-711c2e62d185"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("e6b781e8-2b6a-403d-9cb8-c619ebb0adf9"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("f10666f1-c56a-4057-acbb-7a5118cfb410"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"));

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("c9bc945e-4587-436e-81dd-f5366d7d3ddc"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("99e4216a-32ec-4c51-b5ce-900a7b30710a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9e270e61-2867-450b-8aa0-711c2e62d185"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e6b781e8-2b6a-403d-9cb8-c619ebb0adf9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f10666f1-c56a-4057-acbb-7a5118cfb410"));

            migrationBuilder.AlterColumn<string>(
                name: "UserAbout",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("71e8407a-13ae-4b9e-9666-d288f5a603d4"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5fb550f9-a9c6-4c85-9042-a115628e5417"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null },
                    { new Guid("68a72de0-8c59-44a3-97f2-78361b547c73"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("9bb3e61e-8bf6-4653-a79a-30c72fe2f0b7"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("9f0e2f3a-6662-4713-8716-30c7a00560a7"), 3, false, "F205", 3, null, "Fizik", null, null }
                });
        }
    }
}
