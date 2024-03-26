using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class lessonScoreaddcolumngrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("005d8cec-d17f-40f3-936f-25c308b40cde"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3acbdbd1-ea0c-4805-a143-16033cc7d8fe"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("636efa4d-a58e-44b0-93c4-9436a23b22bd"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7171cbd4-861f-45ea-8069-69dbcab401a3"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fc33dbfa-13a4-43e6-ad98-bd550c35a9b1"));

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "LessonScores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "LessonScores");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 12, 35, 54, 925, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "d41fa173-1f95-4ab2-95af-9b7f9ef00ff5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "e0f9b51b-46a1-421c-8f94-e7f45814b549");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "2b850612-34b1-4529-9e7d-a89cd99ae161");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "771b6fa9-be37-4d71-87d5-d5aa526aab1d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7af6747b-ccb5-46cd-bfda-ea048007200d", "AQAAAAIAAYagAAAAEDxhd4AxOtDcIwl6PuS4gnoBZFRKmJFiM9cNVdDSK0oXUADsZu88OT3yO4O2Z/Zjkw==", "db63b975-0e52-4cef-938d-714bad828b3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d2b0083-c382-4c3d-9c6c-0fb37395852d", "AQAAAAIAAYagAAAAEARI0BIGjjGPA9irH6HBbma50qv1ztVfmztWtfE9O5VSzIivaJJmdi8sXghZe0GEgg==", "c13d0d88-1d42-4195-853a-fe8ce7d43472" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8a905dc-e802-4a31-8631-38b2a768b7a9", "AQAAAAIAAYagAAAAEPzoUqTIDoA88vMHZ0Ro56uJzyNwV273atBG1OdXbr8CeV0IuJnYFR4bhY0Ha3XAxQ==", "566f6c6d-c2aa-4b4e-bf2b-7017716a75b9" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("005d8cec-d17f-40f3-936f-25c308b40cde"), "Undefined", new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(5595), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("3acbdbd1-ea0c-4805-a143-16033cc7d8fe"), "Undefined", new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(8124), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("636efa4d-a58e-44b0-93c4-9436a23b22bd"), "Undefined", new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(8078), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("7171cbd4-861f-45ea-8069-69dbcab401a3"), "Undefined", new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(8098), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("fc33dbfa-13a4-43e6-ad98-bd550c35a9b1"), "Undefined", new DateTime(2024, 3, 26, 12, 35, 55, 168, DateTimeKind.Local).AddTicks(8102), null, 3, false, "F205", 3, null, "Fizik", null, null, null }
                });
        }
    }
}
