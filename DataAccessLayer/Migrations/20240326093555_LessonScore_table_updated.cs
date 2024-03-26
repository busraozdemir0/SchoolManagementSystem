using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class LessonScoretableupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("d17d88ff-5fc9-49ce-b5f7-1cbd34bc402d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("282a3823-c496-4b5a-a8a4-9de392a13f2e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("891c1a25-5374-4740-ae15-1e3b3023bfde"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8a8fe24a-1c80-4a47-8dff-11c6748b112e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d37875e4-d2a3-4d1e-b3c5-8031c7bfbad1"));

            migrationBuilder.AlterColumn<double>(
                name: "Score2",
                table: "LessonScores",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Score1",
                table: "LessonScores",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PerformanceScore",
                table: "LessonScores",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "StudentNo",
                table: "LessonScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StudentNo",
                table: "LessonScores");

            migrationBuilder.AlterColumn<double>(
                name: "Score2",
                table: "LessonScores",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Score1",
                table: "LessonScores",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PerformanceScore",
                table: "LessonScores",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 121, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "640e0b2c-5972-487c-a42a-713094901046");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "18eec6a4-479a-4a86-8d7d-191188f08888");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "a0088d35-36aa-40c3-8691-719ea6d74399");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "078458d0-b73b-418c-b604-cd4a1d914578");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22988a65-b352-4a51-a231-8d8f83b5d96e", "AQAAAAIAAYagAAAAEFA0/yKgyGnBqHTbCB+NJbIODf9ZkPjzqMl+18f0emI8J+uIGFe9UNz/DDWx59L86w==", "69771d63-2611-4f79-93e0-4de2cb14d07b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b00b60a9-71ff-4dab-9d5b-a10eae4c9233", "AQAAAAIAAYagAAAAEOqypQ2ihcmCrsJkiVWjt4VtHd15ktQBfEpJAB6b37o7ik10S+53jqr6yeGwlZFDUw==", "bd60f2f7-d20e-491d-9ddf-ccbe19f22c6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d92f9db1-88fc-4fca-afde-5c3332905767", "AQAAAAIAAYagAAAAEGy1AvIJnhdVFOsk+8/Q9V+QW+6WmQlTppwRxG3a6iYjRfbF16VpS/4UJvdDUK4bRQ==", "a264dacd-cac5-4dfc-8d66-0c1bbef17bf1" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("d17d88ff-5fc9-49ce-b5f7-1cbd34bc402d"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(1669), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("282a3823-c496-4b5a-a8a4-9de392a13f2e"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3330), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("891c1a25-5374-4740-ae15-1e3b3023bfde"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3333), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("8a8fe24a-1c80-4a47-8dff-11c6748b112e"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3312), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("d37875e4-d2a3-4d1e-b3c5-8031c7bfbad1"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3327), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }
    }
}
