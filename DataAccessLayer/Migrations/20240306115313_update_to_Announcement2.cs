using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatetoAnnouncement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 12, 886, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "753e9a08-5f5b-4178-8da2-1c21668b2593");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "990d5470-0ef0-43a9-b107-6a5b42005e13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "95d106d9-ff25-4427-abcf-2213217c2ace");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "26c23a69-6a3e-405c-ba2a-629fc435c2ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec2b04aa-5a92-407d-9673-c054dac40a61", "AQAAAAIAAYagAAAAEFD23krncSpuBHHOTC/0CVx0p5cCkw49baizQn2uqyA3ZTe42Pr6prSzlBQyfg7nLw==", "d1d2bde3-e1c1-421d-83f6-da55c3ee8807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "debc0d19-e2da-462a-aa2a-38760568efb6", "AQAAAAIAAYagAAAAEG7V29t1dhC9/lfco5XxYymA7yzWQ8RZkJwRJn7iMYqbiZomKVqbg5MocUOWP4HfSA==", "543c93f4-4da1-4d83-b07e-6014b3b3e61e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96be7221-3863-444f-8f7e-0661c7af8d68", "AQAAAAIAAYagAAAAEN+F12O0e55p8NRVti9c291Cq/6dZQkoJ2uT+xp3iqi4TmOCTzFnFnepUm8cg3t4zw==", "8b4e0dbf-d83b-4695-86f0-412252e739ac" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("5dc921f3-0a71-47a8-abcd-77f913a0525c"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(1749), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("45faf426-7593-47f8-b924-644284e88376"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3348), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("99f26f35-8bd0-4bcb-8326-73ec522983c0"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3323), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("bda4a05f-778a-41f6-8dc0-1213e3074772"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3351), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("f642e262-f9e4-454c-b32d-68170b3d29ef"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3339), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
                table: "Announcements",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
                table: "Announcements");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("5dc921f3-0a71-47a8-abcd-77f913a0525c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("45faf426-7593-47f8-b924-644284e88376"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("99f26f35-8bd0-4bcb-8326-73ec522983c0"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bda4a05f-778a-41f6-8dc0-1213e3074772"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f642e262-f9e4-454c-b32d-68170b3d29ef"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetRoles_RoleId",
                table: "Announcements",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
