using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddtableDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("97398cce-5125-4b86-9150-907851f88f8a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d7049f23-d728-4d1a-ac0c-1d4365ee0f47"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("dbc67d54-e763-409f-b1a8-55d984a013de"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ee0b3c71-ae3c-40e1-aea3-d86f478e7776"));

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "LessonDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "LessonDocuments");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                table: "LessonDocuments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 265, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressInfo", "CreatedBy", "CreatedDate", "DeletedDate", "EMail", "IsDeleted", "MapLocation", "ModifiedDate", "PhoneNumber", "SupportEMail" },
                values: new object[] { 1, "Düzce Ünv., 81620 Yörük/Düzce Merkez/Düzce", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 265, DateTimeKind.Local).AddTicks(9813), null, "atlaskolej@gmail.com", false, "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12062.0903918608!2d31.180443!3d40.904286!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409da0c35c97aa71%3A0x93cc0b0387c8fc40!2zRMO8emNlIMOcbml2ZXJzaXRlc2kgTcO8aGVuZGlzbGlrIEZha8O8bHRlc2k!5e0!3m2!1str!2str!4v1711622193416!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade", null, "(111) 111 1111", "destek@atlaskoleji.com" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "9c885d7f-2261-426a-8447-b1433525984b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "f65d05fb-7e74-4d92-8622-1aa3d01e23bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "fe7cc3b5-b27f-4539-8ce4-efae3b87f8ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "4e61cb2f-83f1-4f25-9e7d-6659172f4269");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff6b5082-2762-4d78-8a55-6af59d14d6bc", "Kadın", "AQAAAAIAAYagAAAAEAjfPDI14hj+p8FxjH47lWbAtCp/8BKoGpRXozwDUovZ5TPvyqsjb7swkHyP9M0POg==", "225c118b-cd35-4b67-af20-0f021a765782" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046e8b6c-30d7-4c8e-8141-d04adb098669", "Erkek", "AQAAAAIAAYagAAAAEJ3LAvHoFB955ksPMl/oIUlWgAl2ZB3CM7z0h48kjEXMEcGEaxBjlLZPlT6kvOxzXg==", "a37663ac-dafc-4b3d-8e87-662a32251265" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "Gender", "GradeId", "PasswordHash", "SecurityStamp", "StudentNo" },
                values: new object[] { "74647d2f-9746-42ff-9fdc-8128893d4238", "Kadın", 1, "AQAAAAIAAYagAAAAEIEiIXlXkxJJegnSP9ALzd+QPt9oMtF+8YWsG4rTxqUeT1uzr8lcoGFBrWeTe02bzg==", "6feb87f8-572e-4f5e-abf0-4bc6cede6008", 1234 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("40c93997-15f4-4b0c-88f6-079ba6d5eedb"), "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(7925), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6251bce0-538d-4a92-bfd7-119f5b8ef6a8"), "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(7873), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("a70768b9-8c97-490f-8c8d-a2f6b9ccbaa8"), "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(7920), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("f4958b22-1ee8-4ee0-ab8a-4cd8cc33c301"), "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(7915), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("223c8e10-465f-4886-8c36-dd44b18175c0"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9481), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("8a3e4ce7-d3d3-4d7c-8175-189526cc45cd"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9463), null, null, false, null, "Lorem İpsum" },
                    { new Guid("a59eb9d8-a1c1-4ee3-a47b-8918b33c5aac"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9448), null, null, false, null, "Deneme" },
                    { new Guid("a6dcdd21-2fe6-4b02-bdd5-f4d6c292ff35"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9466), null, null, false, null, "Where can I get some?" },
                    { new Guid("b64afe9e-3322-4f2a-a9bb-0e39405935ed"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9461), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("ec23e81a-90e5-421b-89c6-a6dfa31463a8"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 28, 16, 1, 15, 517, DateTimeKind.Local).AddTicks(9484), null, null, false, null, "Bir Ödül Daha Kazandık" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonDocuments_DocumentId",
                table: "LessonDocuments",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonDocuments_Documents_DocumentId",
                table: "LessonDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonDocuments_Documents_DocumentId",
                table: "LessonDocuments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_LessonDocuments_DocumentId",
                table: "LessonDocuments");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("40c93997-15f4-4b0c-88f6-079ba6d5eedb"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6251bce0-538d-4a92-bfd7-119f5b8ef6a8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a70768b9-8c97-490f-8c8d-a2f6b9ccbaa8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f4958b22-1ee8-4ee0-ab8a-4cd8cc33c301"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("223c8e10-465f-4886-8c36-dd44b18175c0"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8a3e4ce7-d3d3-4d7c-8175-189526cc45cd"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a59eb9d8-a1c1-4ee3-a47b-8918b33c5aac"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a6dcdd21-2fe6-4b02-bdd5-f4d6c292ff35"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b64afe9e-3322-4f2a-a9bb-0e39405935ed"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ec23e81a-90e5-421b-89c6-a6dfa31463a8"));

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "LessonDocuments");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "LessonDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "LessonDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 13, 23, 13, 299, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "41f33d9f-7651-4429-aef5-892c65d4291a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "982a0cef-a831-479c-9063-0bb67b9b3122");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "528d4c40-652a-4df3-8d24-c07cd688b0e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "9cb0ef10-d52a-4ca4-8ca5-f4074b0da16c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4663f3f2-b412-4442-9f09-02f4a8333d0e", null, "AQAAAAIAAYagAAAAEMzoihgb9cNmTGjulIaxg11L0OGXXUwxmxVJJJYP/YQy2+eZAHAqnKA2JY4krgVaDw==", "0ee2b483-26d1-481f-b50f-30f06e941ebd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8324fe61-3e5e-48c6-9284-a59dabbe59c6", null, "AQAAAAIAAYagAAAAEFBXW1Wrv3Xiqrun2pNDfvSbkx9uSWRmJ+ybo2M1ilw+5VQC0ccFRh9S5C2TbZUE5w==", "f479e5d0-1e8f-46b9-9556-479854d6b9d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "Gender", "GradeId", "PasswordHash", "SecurityStamp", "StudentNo" },
                values: new object[] { "9fb72f02-23d0-48fb-ab95-1dd8ff90ec4b", null, null, "AQAAAAIAAYagAAAAEESx+Np2sS3XjWooUN+u+ZXCztP+VIy/0tojEgCHDy7/3qndzW2rsByC4oGBBiMEFw==", "f20cad99-4fb3-4102-84bd-cd35a415dc51", null });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 13, 23, 13, 539, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 13, 23, 13, 539, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 13, 23, 13, 539, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 13, 23, 13, 539, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("97398cce-5125-4b86-9150-907851f88f8a"), "Undefined", new DateTime(2024, 3, 28, 13, 23, 13, 540, DateTimeKind.Local).AddTicks(59), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, null },
                    { new Guid("d7049f23-d728-4d1a-ac0c-1d4365ee0f47"), "Undefined", new DateTime(2024, 3, 28, 13, 23, 13, 540, DateTimeKind.Local).AddTicks(88), null, 2, false, "M102", 5, "Matematik", null, null },
                    { new Guid("dbc67d54-e763-409f-b1a8-55d984a013de"), "Undefined", new DateTime(2024, 3, 28, 13, 23, 13, 540, DateTimeKind.Local).AddTicks(91), null, 3, false, "F205", 3, "Fizik", null, null },
                    { new Guid("ee0b3c71-ae3c-40e1-aea3-d86f478e7776"), "Undefined", new DateTime(2024, 3, 28, 13, 23, 13, 540, DateTimeKind.Local).AddTicks(93), null, 4, false, "B101", 3, "Biyoloji", null, null }
                });
        }
    }
}
