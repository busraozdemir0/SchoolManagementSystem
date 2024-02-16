using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateappusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grades_GradeID",
                table: "AspNetUsers");

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

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "AspNetUsers",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GradeID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GradeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "2cb1ba91-4f97-4a04-9914-82e5dbda5268");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "b18ca0ac-53f1-42ab-be1f-f3e631192819");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "aac02758-c7aa-4cc2-9ab8-2030795bb662");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "26d3d05c-1cd6-410b-8e77-fdd72589dbca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfe87037-7ec7-4964-9aa6-2a29ea8d12a7", "AQAAAAIAAYagAAAAEPFtpQ7Vdzzlke1MsB45V0fqyVTi7RWfX7zIM/RxEO6jW+VhO7K6YJxVHwTs1uaH5g==", "73d47cad-485d-43be-ae63-498915622fe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edf01a29-4aa1-4c32-a9a1-45aa7b298c21", "AQAAAAIAAYagAAAAEDsIowTn1R59snJzBNTKl7/e47mj+RoumLy1HbieTMXnPVkTevE31IHXug5RgHS9bQ==", "c561ad39-a7b3-4d54-9a6c-d3593bdb8fa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a71a14-d765-4354-bdc1-7515f3ccb802", "AQAAAAIAAYagAAAAECKbC5SDIOO5aAvhSoYFdokLUVlsgSCgNPIsylD9xydgPk5EZ2gWKwnhT9o76RGxPw==", "17fb25c2-8872-427c-8bf7-705ca0edec8a" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("1cc4f429-ccb1-4bc3-a13f-ef6223cb69cf"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("390c1ab2-4313-4be3-82ef-4c0565a177f5"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("b54482be-887f-4c00-9088-d137dce95567"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("e39691fe-d2cd-47bd-b09b-5e5667cdf8d2"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("e39c3139-277f-48f0-9642-97c6bacc688c"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grades_GradeId",
                table: "AspNetUsers",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grades_GradeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("1cc4f429-ccb1-4bc3-a13f-ef6223cb69cf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("390c1ab2-4313-4be3-82ef-4c0565a177f5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("b54482be-887f-4c00-9088-d137dce95567"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e39691fe-d2cd-47bd-b09b-5e5667cdf8d2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e39c3139-277f-48f0-9642-97c6bacc688c"));

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "AspNetUsers",
                newName: "GradeID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GradeId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GradeID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grades_GradeID",
                table: "AspNetUsers",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "Id");
        }
    }
}
