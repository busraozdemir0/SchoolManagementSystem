using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateannouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_UsersId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_UsersId",
                table: "Announcements");

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

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Announcements");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "e47d448e-01af-4320-8c43-dc376c2668a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "50fcacce-90a8-4511-9bdc-5375cce2f20b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "b41b0275-39be-4101-be0d-c79bb96d2c19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "762f300a-9c45-4e78-89d6-3fbea757761f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ffc0725-8794-4d2b-9c1f-d9e6dc44c4a3", "AQAAAAIAAYagAAAAEAzRk0YsLeEx0o0lsS79kdAOZ+kW1A8dHRzRW+yLhRo9TZxrZr/UivJBsZLv4gqRWw==", "581e81e1-74a1-43b2-81a8-e1d5a4c2c36a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19d3530f-bd03-4e8e-ab26-74f121f7a0cd", "AQAAAAIAAYagAAAAEFX7H2lWho8ROljG2OjzDGRt3H8xHy6qD6XSGcxtCVqH22sRzL8VZia0dVnX76DHAQ==", "ed7d323e-8004-439e-9014-87a700c4fd2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abf0ab3a-f28d-4924-b609-61f60a97b40a", "AQAAAAIAAYagAAAAEDODKH/a/cRH2ii0nFDNxYfRYxEzk54+YZW9JY0eT/EqEwXKwc1MNT0KvgN6+rFAZA==", "de5f6d76-f846-4e0d-8f30-1e5a2f5b7fc8" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("d5190e35-ad72-4c91-907a-fbfce5ec85d5"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7aec959a-46e9-4e67-adfe-4045776ebeb7"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("aae96644-86e9-44bd-843d-bb70528caa3d"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null },
                    { new Guid("bf5e8c77-747a-4297-bb80-f90d4e86dde1"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("e0371e1f-ae2c-4c48-aa78-00f1e2a6969c"), 4, false, "B101", 3, null, "Biyoloji", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_UserId",
                table: "Announcements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_UserId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("d5190e35-ad72-4c91-907a-fbfce5ec85d5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7aec959a-46e9-4e67-adfe-4045776ebeb7"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("aae96644-86e9-44bd-843d-bb70528caa3d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bf5e8c77-747a-4297-bb80-f90d4e86dde1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e0371e1f-ae2c-4c48-aa78-00f1e2a6969c"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "e83c80f0-bf80-4c7f-9778-82ce74ca481e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "1d5f305b-69fd-45a5-9de2-7a4b957672c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "e528f92e-b56c-41c2-94a2-a1fbac603ecd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "89024944-2914-483f-bfe8-dde691035710");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8db8df-82b0-4d50-96d8-1a6194383dcd", "AQAAAAIAAYagAAAAEGC7YIrkIQdIOHIPW7IJ5jDoE+ZGX6BkwCXV22ubWCtt/NrSuoIY/7XL8pwnryFxnw==", "d466cb1b-4435-46ac-9a8c-74cc004b08f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdbebaeb-e346-4f27-9b81-f3a57c4cc096", "AQAAAAIAAYagAAAAEEgnkEnA2Naz5DqYQY9uU9mK+PrtnRzpFQ36RiM3W8HUWjKoyj73R+Qr5G6Ith00gw==", "f1357844-3e1f-46ae-a4fa-0ce47953ccbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38b14f87-e512-4cd1-8a98-d37adfe38ba8", "AQAAAAIAAYagAAAAEFneWvHeEPtIM38I0+Fws6CjP8m0y/5RLNWN+qHVVtGMPmkmWTqsLmg9rShauY66zw==", "17602b8b-31d4-47e5-9f27-b1edb680450d" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UsersId",
                table: "Announcements",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_UsersId",
                table: "Announcements",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
