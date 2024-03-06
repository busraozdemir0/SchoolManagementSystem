using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migAnnouncementaddcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Receivers",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 13, 8, 36, 551, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "46b0e358-e6c9-402e-8461-29ca03e63f5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "e0a7e58d-a353-4420-8a62-8b613b0fe925");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "e8323889-d9a9-4c84-ac32-ea442b554295");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "3882b411-2a80-403c-b651-6e0c3d122f48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5c47305-7f29-4201-962a-38bffadb7c1f", "AQAAAAIAAYagAAAAEJr6WLtCmM8x9wuInb3PWGpEl+OOqr8O6lxA2z8hBl4YEPTqt4vF6quZDcTlSplxKA==", "6976ad67-a68c-4168-b73f-049e1f6faa05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b9fbbae-fe85-43d7-8538-a12bf42855b1", "AQAAAAIAAYagAAAAEBk8keUuISDPHIO7uk4mStIG9b5xBxPbdl/eEUw/lCk8L9n396msOHml/pip0GLPzA==", "e2d985a0-d7cd-466c-855e-f7d30e3ac65e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb350d55-5576-4831-90f3-59841f6aee87", "AQAAAAIAAYagAAAAEHzmlvrCFC8MpZ2QoT55E4a8Dai1lCIxI8LtyETtGvDjgYg36w6abQZi6PexLwAFwg==", "cdfd48c3-f040-4e7e-973d-2d9f17e28562" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 13, 8, 36, 853, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 13, 8, 36, 853, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 13, 8, 36, 853, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 13, 8, 36, 853, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("bb8838ea-0977-4704-8a86-99f9ac76ba58"), "Undefined", new DateTime(2024, 3, 6, 13, 8, 36, 853, DateTimeKind.Local).AddTicks(9273), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("282897a3-550e-4a89-a0a0-b5b1b290f0f1"), "Undefined", new DateTime(2024, 3, 6, 13, 8, 36, 854, DateTimeKind.Local).AddTicks(1411), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("2ad9b071-9a44-4b97-ad4d-c12509ac740a"), "Undefined", new DateTime(2024, 3, 6, 13, 8, 36, 854, DateTimeKind.Local).AddTicks(1391), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("4623163f-2c8b-40dc-8156-eb47320713f8"), "Undefined", new DateTime(2024, 3, 6, 13, 8, 36, 854, DateTimeKind.Local).AddTicks(1425), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("6f77de73-ac23-4a72-b632-b0bff7d53e50"), "Undefined", new DateTime(2024, 3, 6, 13, 8, 36, 854, DateTimeKind.Local).AddTicks(1437), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("bb8838ea-0977-4704-8a86-99f9ac76ba58"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("282897a3-550e-4a89-a0a0-b5b1b290f0f1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2ad9b071-9a44-4b97-ad4d-c12509ac740a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4623163f-2c8b-40dc-8156-eb47320713f8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6f77de73-ac23-4a72-b632-b0bff7d53e50"));

            migrationBuilder.DropColumn(
                name: "Receivers",
                table: "Announcements");

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
    }
}
