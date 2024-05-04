using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addtableSocialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("275af842-5c67-4e41-a389-35c2ac64ef7d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("68a95ac2-0de8-4351-88c9-e35a5e19f984"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7d4b49ed-8bd1-4449-b4d6-077ab2e5baae"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fbc5e29e-d59a-4f51-b518-d269aa26a666"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("169f1412-de7e-4121-8522-10eb5c47a45b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("4dac7b8e-39f5-47d3-8486-7962261ea365"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5a5c5ce3-a606-4917-9f15-dfd8d03580be"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ab9c81e4-9fe7-43f6-8c36-65bf38da7ac3"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b19b2ad5-b70f-4db8-99c6-86e350557275"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c9eed4da-a9cf-4e86-a1cc-8d7505c59853"));

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 86, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 86, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "4fd57580-0637-4705-8daa-4dcb91cb6b4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "f1eb1dee-773d-4a46-98d9-b8b43dd64a21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "6c7321a7-c0ba-439b-976a-c123ce96e4fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "f8b0965b-f913-47ea-914d-280d2e89074e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2388a6a0-fb3e-43c2-9ee4-52a8ed64110a", "AQAAAAIAAYagAAAAEFY8bkMxUBCOrEVgIwiZ6iIp0EcO0CWiGPYgepAzQ8VDNBQDMJcZVxfp7lw8GoALjA==", "278e1604-baa7-4db1-b0c6-d67875f5118f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f31e622e-8231-4ef5-91e0-0164d97c94d4", "AQAAAAIAAYagAAAAECOPKhldLYET3ZUcvAQemJIeomGvzUv5LsLYdfV4Viz5qasjWXDAVsebUKkxoaBlSQ==", "bccdeb31-15b0-4be3-9d8b-38f1808fb45a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d364aba8-fac4-46ac-8b9e-61e6223c9f87", "AQAAAAIAAYagAAAAEA0tO4+zlgO5+Syz6ZJ3TsOkNuqlM+JdyHFXlO72CBZ6OlCYN5wX0f+vleO5sEctWQ==", "cd253a31-8c5d-4fa8-993f-5e7c0e973741" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 519, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 519, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 519, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 16, 49, 519, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("4aefb370-4e28-4882-94cb-eb859819a6c4"), "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 520, DateTimeKind.Local).AddTicks(1175), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("528b4720-0ee4-49e2-9786-82963a45fa09"), "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 520, DateTimeKind.Local).AddTicks(1105), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("c14fa414-852c-4200-af68-9cde7a3b8f1c"), "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 520, DateTimeKind.Local).AddTicks(1154), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("db89ee93-c2fb-423d-bc64-669d2588e384"), "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 520, DateTimeKind.Local).AddTicks(1159), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("00246b01-44b2-42b7-bceb-a616c3e37f84"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3669), null, null, false, null, "Where can I get some?" },
                    { new Guid("359af8a2-0508-4670-92a9-5c63bf73731e"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3640), null, null, false, null, "Deneme" },
                    { new Guid("a2d286e2-9503-4342-bd16-a631590b6502"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3667), null, null, false, null, "Lorem İpsum" },
                    { new Guid("b2395d05-2324-4360-b872-395fb0c39761"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3664), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("c50e23e9-12ee-4340-ba5e-b807a64a853c"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3674), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("df2feb47-e58c-4445-9cd9-1015f8508fba"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 16, 49, 521, DateTimeKind.Local).AddTicks(3672), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4aefb370-4e28-4882-94cb-eb859819a6c4"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("528b4720-0ee4-49e2-9786-82963a45fa09"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c14fa414-852c-4200-af68-9cde7a3b8f1c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("db89ee93-c2fb-423d-bc64-669d2588e384"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("00246b01-44b2-42b7-bceb-a616c3e37f84"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("359af8a2-0508-4670-92a9-5c63bf73731e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a2d286e2-9503-4342-bd16-a631590b6502"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b2395d05-2324-4360-b872-395fb0c39761"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c50e23e9-12ee-4340-ba5e-b807a64a853c"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("df2feb47-e58c-4445-9cd9-1015f8508fba"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 216, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 216, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "94a90224-96bd-4f5d-80a4-923d6c7ad497");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "6307d8c2-f81f-4121-8c04-e30b8bc46d70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "8d7a36d2-4fad-467d-97db-b171d8462e26");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "52218f94-9095-4845-a049-58ea51403846");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd8bbb74-f1bd-4359-96e3-f81739e15600", "AQAAAAIAAYagAAAAELgtJ6MGq7+upK/noPzwnmatei9p/IXUsgqnelUrKoZPw9U00gxpp3EPjzzBbwpClw==", "8b00860b-3742-4d74-8094-105f04f5ce22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "155e6559-c795-4218-a787-0f053e0a48d7", "AQAAAAIAAYagAAAAEMeiTDERn3inROwvwVsK5bdGfA9Z8uXRydU/khZ87DHXclXIGO+LNkL/yrzfna/81g==", "00f06288-6f08-44b7-8388-ed473cced7ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a82b52fd-8fd1-41a6-84cf-6196163faab6", "AQAAAAIAAYagAAAAEBmcyDArQXaXZWOT3a1fI+ZZqe42yOHToxUAB00mF9dWhPys6dVuwg2jN7ZRyxfanA==", "3b6bd258-8419-4425-8b67-cd5cd71a3496" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("275af842-5c67-4e41-a389-35c2ac64ef7d"), "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(8746), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("68a95ac2-0de8-4351-88c9-e35a5e19f984"), "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(8739), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("7d4b49ed-8bd1-4449-b4d6-077ab2e5baae"), "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(8743), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("fbc5e29e-d59a-4f51-b518-d269aa26a666"), "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 460, DateTimeKind.Local).AddTicks(8699), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("169f1412-de7e-4121-8522-10eb5c47a45b"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6474), null, null, false, null, "Where can I get some?" },
                    { new Guid("4dac7b8e-39f5-47d3-8486-7962261ea365"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6430), null, null, false, null, "Deneme" },
                    { new Guid("5a5c5ce3-a606-4917-9f15-dfd8d03580be"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6476), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("ab9c81e4-9fe7-43f6-8c36-65bf38da7ac3"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6472), null, null, false, null, "Lorem İpsum" },
                    { new Guid("b19b2ad5-b70f-4db8-99c6-86e350557275"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6483), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("c9eed4da-a9cf-4e86-a1cc-8d7505c59853"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 30, 13, 20, 59, 461, DateTimeKind.Local).AddTicks(6463), null, null, false, null, "Gelecekte Yapay Zeka" }
                });
        }
    }
}
