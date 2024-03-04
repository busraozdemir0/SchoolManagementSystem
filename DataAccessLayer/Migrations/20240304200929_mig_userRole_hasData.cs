using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class miguserRolehasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2024, 3, 4, 23, 9, 28, 72, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "e66eb0f1-cc0e-4138-b2fc-cfe912f28521");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "0219afc3-b6f8-438c-9990-9ae090119846");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "977387e2-d053-4e43-9e05-e414b318e3e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "81cf62d3-edf0-45e9-ab2b-9e2bac3d4b42");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("23420044-c9ae-462e-8317-88db8c734de1"), new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"), new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8") },
                    { new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"), new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0da5198-d11b-4d14-b2f7-fecab0cc8a24", "AQAAAAIAAYagAAAAEAUam7+FITwE8glfdAJKI7VF+K1fvfCQSbn/tQFItasXrnPyZYhv/1BAtvUVkoyeyw==", "7d3460ba-817a-49a9-8d4e-7eb2fb55a05c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61393cc3-0422-4e6d-9251-c45fe468664f", "AQAAAAIAAYagAAAAEFAz7M2QmDvg0yv17Kh8ibwDxFAYkHVsFogfFb4gzGYY+nKErv1pId0jaZHysgx71Q==", "b0be9a21-7724-41b4-9c76-fcfbf0942943" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec68195-3fe5-40d0-a2ba-4071af3b2b1c", "AQAAAAIAAYagAAAAEGMydcrQX4HmUY8VlCw6civh0LCgQXPruupvMbvItBb5xG7S2Vb1Fy/1eUwIkg90pw==", "eebdcebe-8e6c-485e-b5c5-f24fc686993e" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("1cdeeeff-5649-4fb8-b484-f665e7b0b62c"), "Undefined", new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(7031), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("9f4f9d90-f97b-487d-9950-ffe0ee2e9105"), "Undefined", new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(8588), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("cec254ee-3967-4cdb-9f19-c2e3ebccdcf2"), "Undefined", new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(8586), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("d2307378-c756-42d3-a63c-71783012831d"), "Undefined", new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(8583), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("d9506fcb-7cb2-4a24-97ee-666e7be04efb"), "Undefined", new DateTime(2024, 3, 4, 23, 9, 28, 341, DateTimeKind.Local).AddTicks(8568), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("23420044-c9ae-462e-8317-88db8c734de1"), new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"), new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"), new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76") });

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("1cdeeeff-5649-4fb8-b484-f665e7b0b62c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9f4f9d90-f97b-487d-9950-ffe0ee2e9105"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("cec254ee-3967-4cdb-9f19-c2e3ebccdcf2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d2307378-c756-42d3-a63c-71783012831d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d9506fcb-7cb2-4a24-97ee-666e7be04efb"));

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
    }
}
