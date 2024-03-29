using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddtablevideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "VideoName",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "LessonVideos");

            migrationBuilder.AddColumn<Guid>(
                name: "VideoId",
                table: "LessonVideos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeVideoPath",
                table: "LessonVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Videos",
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
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 58, 878, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 58, 878, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "7f709f10-92fa-4fc7-ae9c-b02649585b1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "4f622642-2281-4e87-9501-ef49707ef0b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "f6c4f9a3-6956-4281-a0ae-26391a625dc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "d18316c0-caa2-43e0-b39c-1bae0944cc16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e528995e-9fd5-43d7-b40c-f313c5536a1a", "AQAAAAIAAYagAAAAEGamahZ4oUbxdFzA6sKZS/1+j2SXBV1mNU1wja9q50VaeZxOvsg4w3koeANSqHOvIA==", "d048343b-c30f-4768-bf48-3442c1404bf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d0e4905-5f95-4afe-9947-bdcfb7007cb1", "AQAAAAIAAYagAAAAEKFjSjipeJDJxFv1ejUuChLVH+6Moi0e5G0zzM24xqM8CNX0QbwiYcDHdBWfAuEW7g==", "f9b0ce49-b361-4a9d-b57e-dd864f346dec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6107d1ec-6698-41d9-941d-7b8f22b079ee", "AQAAAAIAAYagAAAAEGhbufXi4eHbzruec2M/wnXv0/v5WnZoSPqoVllTmPKwYLnARJ59ITPTNHh2Opm74g==", "13ec82b2-fa25-406c-9426-dc9c1a1a523f" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("08c9f7b0-5221-4536-a27a-dad4bb059179"), "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(4631), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("2769fc79-a040-47c9-ac1b-3a40e9ef4b77"), "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(4648), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("3f5f0bbc-e1a8-46c7-8e72-ebd0ddff9c8a"), "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(4635), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6a1c3fba-31b8-4980-81ba-d160ac742c08"), "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(4590), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0c587623-f593-4d64-8440-c42db26c86f1"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7489), null, null, false, null, "Where can I get some?" },
                    { new Guid("28c58b29-6873-4f82-bfb6-1b5fa500432a"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7487), null, null, false, null, "Lorem İpsum" },
                    { new Guid("3d246772-c12c-4d79-a48e-fcc751a11a65"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7492), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("4ab20ed0-4af8-4dd7-89c2-f6ab5ca10d86"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7477), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("7866b9a7-9b71-4ecc-9437-b8f390557644"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7494), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("eda0bb1d-13bf-478d-8ef9-8b8448262345"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 3, 29, 15, 51, 59, 147, DateTimeKind.Local).AddTicks(7460), null, null, false, null, "Deneme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonVideos_VideoId",
                table: "LessonVideos",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonVideos_Videos_VideoId",
                table: "LessonVideos",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonVideos_Videos_VideoId",
                table: "LessonVideos");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_LessonVideos_VideoId",
                table: "LessonVideos");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("08c9f7b0-5221-4536-a27a-dad4bb059179"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2769fc79-a040-47c9-ac1b-3a40e9ef4b77"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3f5f0bbc-e1a8-46c7-8e72-ebd0ddff9c8a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6a1c3fba-31b8-4980-81ba-d160ac742c08"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0c587623-f593-4d64-8440-c42db26c86f1"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("28c58b29-6873-4f82-bfb6-1b5fa500432a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3d246772-c12c-4d79-a48e-fcc751a11a65"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("4ab20ed0-4af8-4dd7-89c2-f6ab5ca10d86"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("7866b9a7-9b71-4ecc-9437-b8f390557644"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("eda0bb1d-13bf-478d-8ef9-8b8448262345"));

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "YoutubeVideoPath",
                table: "LessonVideos");

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "LessonVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoPath",
                table: "LessonVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 265, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 16, 1, 15, 265, DateTimeKind.Local).AddTicks(9813));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff6b5082-2762-4d78-8a55-6af59d14d6bc", "AQAAAAIAAYagAAAAEAjfPDI14hj+p8FxjH47lWbAtCp/8BKoGpRXozwDUovZ5TPvyqsjb7swkHyP9M0POg==", "225c118b-cd35-4b67-af20-0f021a765782" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046e8b6c-30d7-4c8e-8141-d04adb098669", "AQAAAAIAAYagAAAAEJ3LAvHoFB955ksPMl/oIUlWgAl2ZB3CM7z0h48kjEXMEcGEaxBjlLZPlT6kvOxzXg==", "a37663ac-dafc-4b3d-8e87-662a32251265" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74647d2f-9746-42ff-9fdc-8128893d4238", "AQAAAAIAAYagAAAAEIEiIXlXkxJJegnSP9ALzd+QPt9oMtF+8YWsG4rTxqUeT1uzr8lcoGFBrWeTe02bzg==", "6feb87f8-572e-4f5e-abf0-4bc6cede6008" });

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
        }
    }
}
