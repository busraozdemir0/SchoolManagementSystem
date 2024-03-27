using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migabouttableaddSchoolNamecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("334eedf1-0411-44ab-a09a-2e254b6a8063"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("54899adb-7a9e-4272-a2e3-ad72d0103d92"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("60e54a0c-7f92-4669-84c1-f6fdba16d744"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a8d5279c-667d-4859-82c3-4c1b32af3c25"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c4ddd08e-ef69-4907-b95f-4dcf269c7a53"));

            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "SchoolName" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 57, 19, 535, DateTimeKind.Local).AddTicks(6785), "Atlas Koleji" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "b5b67ee7-d6d2-495d-8af0-180d23bee499");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "bf95a043-e71c-4f2f-abdb-354d90486e70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "1cbdef18-7a00-43a5-9f2d-cb8cfa65a4b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "152ee2a2-69e6-4425-b81b-32b0a89d8493");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac9668a-ede3-4c63-8b3f-06df655cdcb0", "AQAAAAIAAYagAAAAEFxMGfDNdd2ywbMsfEE3mXuKRyxsIbLjd2r4MAZC9fQfgwoPcVw9teu68VU3iN4INA==", "dc6092a9-a467-4bb6-aadf-72a33b644a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c262b1c-2aad-453d-b03e-8f14acbe1ccb", "AQAAAAIAAYagAAAAEPog6rU8yLYAcLgV/wtCpRLu0SHmHhyt4nG9w1rp/YB318xRhtTPRvLsSXHFZfiISA==", "a0273755-c5f0-4bbe-b413-a842e78ca7f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d4b1349-8c9a-4635-9d57-e0d1a5578e09", "AQAAAAIAAYagAAAAEHW8YCmnDsWeeBUpoLNfoOe4UxEgYageQo8iReRgMyOWwn7zRWrTwr26Kb4VhzXK0w==", "fc9f55be-0f1b-4a88-8469-71d465774878" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("3a9ed01e-1379-42ba-8457-82522e7626e1"), "Undefined", new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(2901), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f882274-4f30-46fb-b361-50707de07f0f"), "Undefined", new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(4296), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("807f7d8e-30cb-4269-9f0f-f7e5098d05d3"), "Undefined", new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(4314), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("9f931488-60d9-4e32-8ec3-2b969337a178"), "Undefined", new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(4316), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("d4b9b2ea-a4ba-4ddd-a452-755038fa4010"), "Undefined", new DateTime(2024, 3, 27, 15, 57, 19, 794, DateTimeKind.Local).AddTicks(4311), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("3a9ed01e-1379-42ba-8457-82522e7626e1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5f882274-4f30-46fb-b361-50707de07f0f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("807f7d8e-30cb-4269-9f0f-f7e5098d05d3"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9f931488-60d9-4e32-8ec3-2b969337a178"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d4b9b2ea-a4ba-4ddd-a452-755038fa4010"));

            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "Abouts");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 15, 36, 29, 160, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "1bdeccd3-7f70-49ce-ad6c-67df6d448770");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "928df619-7f79-4f2f-a415-f83188a995b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "0d7c86e5-0ecd-46f8-869b-f089968a0579");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "b68d8012-f2c5-4a87-93da-05c81972bd0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8830f2fc-9f01-4c6b-ab77-eb593f9d6646", "AQAAAAIAAYagAAAAEFr1aab8mEaBn+9DkpIjWOKlp4L6p1nO2raKVjz1aZ1A7BJME+fa4HY8Wk3AtAPC6A==", "f0aee83d-01f2-4ff3-8b96-70ab7df69573" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "317ea74e-f700-4f40-93a0-161ef667044c", "AQAAAAIAAYagAAAAEBRjf285LCu0vIveGQcaAq7eoo1qtz6aPFQYn89DvKek2+2nPX5enkFxy33Hp+wRDw==", "25fa031d-db65-4087-8287-eeee4b7781ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e889a1b3-2bb2-4a55-9c86-d03da68083fe", "AQAAAAIAAYagAAAAED8aYCoRlKk7VS8RWAV/pRM+TRqqA4gafVHjRGYLrfPFm02CIu9K5h0MkelA0jAhng==", "6b0d3add-afa9-43cf-8762-6f62fa1b27d3" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("334eedf1-0411-44ab-a09a-2e254b6a8063"), "Undefined", new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(2669), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("54899adb-7a9e-4272-a2e3-ad72d0103d92"), "Undefined", new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(4451), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("60e54a0c-7f92-4669-84c1-f6fdba16d744"), "Undefined", new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(4431), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("a8d5279c-667d-4859-82c3-4c1b32af3c25"), "Undefined", new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(4454), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("c4ddd08e-ef69-4907-b95f-4dcf269c7a53"), "Undefined", new DateTime(2024, 3, 26, 15, 36, 29, 403, DateTimeKind.Local).AddTicks(4448), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }
    }
}
