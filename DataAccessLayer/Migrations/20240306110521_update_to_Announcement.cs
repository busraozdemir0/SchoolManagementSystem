using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatetoAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 5, 20, 663, DateTimeKind.Local).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "f1c892d4-5511-494a-929e-a5d6063bd04a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "e2656ef4-ece7-4b13-9d89-70d4d5f8b020");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "b71eca89-14d4-48ee-ac1c-949be818e09f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "b023c3ed-5520-499a-835e-2e0a9ba6d1ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a30575b4-39f4-4442-a9d9-9664271eb45a", "AQAAAAIAAYagAAAAENulbP/6DMg6IKZVj3S+tUGzcO4f2tgTjSIWQQGp3vXcKsRh7dMHxjG+U+FKsSOrpg==", "90c6a13f-7e74-4966-8b35-7471d6c6fb19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff6250e-8f10-43f7-88cd-b694f1f1e5fb", "AQAAAAIAAYagAAAAEP+T6D/4hXBqjJfI+FjYhzHDZiZGtQXflGRvFkM6JYqteEjM6NUAxZHIZjUbRf66Yg==", "458a33f1-93c3-4ac9-b470-a39ec361991f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b39ad6d-a7da-4956-ac0b-1fab73bdd782", "AQAAAAIAAYagAAAAEE6Fk+5eoCa39QSBBNhkaI7suNZiMi4Bu8N3u6qXsjl4LSDvBkIoun/uJnXz5VBW5A==", "37d1aeab-eae2-47cd-a64e-714f9dc89034" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 5, 20, 963, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 5, 20, 963, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 5, 20, 963, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 5, 20, 963, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("3f26e199-9c8d-4c80-a906-27dc212aa116"), "Undefined", new DateTime(2024, 3, 6, 14, 5, 20, 963, DateTimeKind.Local).AddTicks(9133), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ec1da68-ad68-4894-82ab-321e2c67f709"), "Undefined", new DateTime(2024, 3, 6, 14, 5, 20, 964, DateTimeKind.Local).AddTicks(649), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("44ef292b-9317-4a68-a2da-5fc8fae0ba07"), "Undefined", new DateTime(2024, 3, 6, 14, 5, 20, 964, DateTimeKind.Local).AddTicks(644), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("b7fbb974-afb0-45b1-8937-77de61d7278c"), "Undefined", new DateTime(2024, 3, 6, 14, 5, 20, 964, DateTimeKind.Local).AddTicks(652), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("fd25f205-4714-4cde-a64d-c0f90d66760b"), "Undefined", new DateTime(2024, 3, 6, 14, 5, 20, 964, DateTimeKind.Local).AddTicks(546), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RoleId",
                table: "Announcements",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
                table: "Announcements",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_RoleId",
                table: "Announcements");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("3f26e199-9c8d-4c80-a906-27dc212aa116"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ec1da68-ad68-4894-82ab-321e2c67f709"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("44ef292b-9317-4a68-a2da-5fc8fae0ba07"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("b7fbb974-afb0-45b1-8937-77de61d7278c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fd25f205-4714-4cde-a64d-c0f90d66760b"));

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Announcements");

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
    }
}
