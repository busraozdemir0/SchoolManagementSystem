using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migentityctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("49551ea5-5729-4ffa-99b4-a40a83561e4a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0d48970d-bfbb-4c2f-a9a8-dee3426b6970"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2c9c26f1-9f9d-4443-be85-00cd6e712541"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a56eaab7-00ad-49bc-ad4a-3d083fbde5de"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("eb72fb64-2e0a-474f-9066-ebb8d577801e"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 15, 29, 9, 356, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "3e21fb21-6d97-44af-b02d-f357c3cdd9b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "b1f1d044-8011-4b52-8949-b28a6ac94430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "f766e801-bf92-4bc4-b72c-4cbf13ce154c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "7e4c0ace-bb68-453d-9c85-95414b311399");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8f73bca-d580-4e7b-9627-c41c86cc44f4", "AQAAAAIAAYagAAAAEElBL87P7mYFu8ibS3XS/dOoxKARlUf4V0mHAlu9Ohjnu08bMYg+xzBDESH7vhZjfA==", "6c236dd0-20a6-463a-be3b-fba04e01e7ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a91f2a-4db7-47cc-a98d-308682d0ec61", "AQAAAAIAAYagAAAAEEI61FwF8NvsI37eSug6A5dwCvfyr3qML5yQfeJjX+Qt9dPN2okThE6iRgziE0cc1Q==", "038cf655-1d44-409a-9d33-6740d979d004" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdcb84b5-6558-4bcd-9a59-6e2d63ee23d1", "AQAAAAIAAYagAAAAEE1cKwEUu04CSk+fRFB2XvRAh0eEEiN980GkqguWOS8tJquAAw5HKHJbTQxk+ruThQ==", "e2d41f0c-72a6-4fd0-8db4-5b56e9282ba6" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("e8f674df-eae9-4842-a6b2-225afdfee1cf"), "Undefined", new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(5510), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("66431cf3-21ce-4b04-8edf-f5dc9473db16"), "Undefined", new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(7117), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("74555474-9687-4597-ad83-c5b7bf1c33e0"), "Undefined", new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(7102), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("83891777-e2a5-42c4-b10c-bbc5c74b391b"), "Undefined", new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(7121), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("fa0caf66-2406-4687-8fd2-961f64cd0071"), "Undefined", new DateTime(2024, 2, 27, 15, 29, 9, 618, DateTimeKind.Local).AddTicks(7123), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("e8f674df-eae9-4842-a6b2-225afdfee1cf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("66431cf3-21ce-4b04-8edf-f5dc9473db16"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("74555474-9687-4597-ad83-c5b7bf1c33e0"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("83891777-e2a5-42c4-b10c-bbc5c74b391b"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fa0caf66-2406-4687-8fd2-961f64cd0071"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 2, 824, DateTimeKind.Local).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "50bc3a61-5cca-41fd-8aee-2307d104dcf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "d838bfb0-dba7-453a-b3fc-fbbbc20d63dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "91e3a231-5563-4089-bccc-f4d6c171015f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "8405387e-7a57-411d-bb58-b09b05925918");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86dca315-5082-44f9-b78d-b3f2174d6c42", "AQAAAAIAAYagAAAAEMYWcwdVfrvNAJqJ9ozZItpXK3IGDpwW6BtxUzzv/F2lJxuzMgxW4DQZFmMJZUeT8w==", "db8a9046-ae97-4439-b226-0b055750066c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8979283-0795-4d78-81ae-694b1be393ed", "AQAAAAIAAYagAAAAEMFonqzBdI7mJSvN0/kKTUXNkPApOh8YWBOV41IQ0PijdkzgeYRrG6+Qaf6L85RMGg==", "67f3ebdd-60b0-4601-9044-f1f6f406c9d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4544bb-afd4-46f4-87ca-72269713af52", "AQAAAAIAAYagAAAAEHYOdwGzC/riayI/FqWACda3Wj8AL1AzoRIPkKavtOwhFkiyT4I8y77VWKvUlq04Kg==", "0baf6893-e0f3-4e00-bb65-3edc47b1ae66" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("49551ea5-5729-4ffa-99b4-a40a83561e4a"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(84), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d48970d-bfbb-4c2f-a9a8-dee3426b6970"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3052), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("2c9c26f1-9f9d-4443-be85-00cd6e712541"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3057), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("a56eaab7-00ad-49bc-ad4a-3d083fbde5de"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3004), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("eb72fb64-2e0a-474f-9066-ebb8d577801e"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3044), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }
    }
}
