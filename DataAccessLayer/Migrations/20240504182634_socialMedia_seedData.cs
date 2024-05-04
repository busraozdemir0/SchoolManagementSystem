using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class socialMediaseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2024, 5, 4, 21, 26, 33, 882, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 26, 33, 882, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "bc2f39bb-4d9a-4435-ab69-fa2b916b1b34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "04f0502d-3e37-43c8-9a24-6fad71ff1a79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "c7669e9a-6a99-4786-9c12-a1647b44d248");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "a576da07-d533-4f9c-882c-6472d6f1625f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71d06f13-d6b8-4028-bbbb-edc3f3b42ad7", "AQAAAAIAAYagAAAAEDPz3crATtPsHny+R4FK9J283qjy8TWD+AseTyBEPfJMCxqcbySSVNefIj3bvMn+sg==", "3c1591f1-7664-47b9-b18f-49ebef9fa983" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "934271a7-9428-473c-ab57-302eb97e5b94", "AQAAAAIAAYagAAAAEISphJYTJ6vxs+oZ/D377yKJtHymMrKTnxSTBGRayrVnZfF2q2p3JqUWWC9XfcrJww==", "2a8dc6f7-6bb0-46a7-9328-f96ee03a8b4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf1486b7-7221-4b16-b2ae-e5970a1b4323", "AQAAAAIAAYagAAAAEC6RuqJRiEkGUWxKBouYK6JtKdj7jC6bYhpNhHoQm6aD/RjlporszuZUQ6lYCQuoJw==", "fdf214a4-2faf-49bd-b77d-7db6cddf3608" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("79714268-ca62-4982-95ee-6e8d8682fe6a"), "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(8983), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("88f0eb39-a9bd-4f45-9e8a-e1500e62d0d1"), "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(9026), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("e1e90fc1-750a-493c-8b65-9ed7846df4e5"), "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(9031), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("e48075b2-4b38-406e-b64c-a2164131c211"), "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 169, DateTimeKind.Local).AddTicks(9034), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("090ab747-d43c-4179-9f36-30e3a3749509"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6365), null, null, false, null, "Lorem İpsum" },
                    { new Guid("1cb1b34f-cbc3-468b-aabf-808f0ff8017a"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6386), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("3f072d7e-c2f3-4a3b-8edf-7a86fe45dd25"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6355), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("41e975c4-6284-4604-851a-d8824bda1fd7"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6379), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("5f262550-5121-421e-91e1-50217553ad0f"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6377), null, null, false, null, "Where can I get some?" },
                    { new Guid("d8ba4661-d6b7-4f93-992b-fbc17e1268d1"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 5, 4, 21, 26, 34, 170, DateTimeKind.Local).AddTicks(6340), null, null, false, null, "Deneme" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "IconInfo", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "fab fa-linkedin", "LinkedIn", "https://www.linkedin.com/in/busra0zdemir/" },
                    { 2, "fab fa-github", "GitHub", "https://github.com/busraozdemir0" },
                    { 3, "fa-brands fa-x-twitter", "X", "https://twitter.com/busraozdemiir" },
                    { 4, "fab fa-instagram", "Instagram", "https://www.instagram.com/busra.0zdemir/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("79714268-ca62-4982-95ee-6e8d8682fe6a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("88f0eb39-a9bd-4f45-9e8a-e1500e62d0d1"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e1e90fc1-750a-493c-8b65-9ed7846df4e5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e48075b2-4b38-406e-b64c-a2164131c211"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("090ab747-d43c-4179-9f36-30e3a3749509"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("1cb1b34f-cbc3-468b-aabf-808f0ff8017a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3f072d7e-c2f3-4a3b-8edf-7a86fe45dd25"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("41e975c4-6284-4604-851a-d8824bda1fd7"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5f262550-5121-421e-91e1-50217553ad0f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d8ba4661-d6b7-4f93-992b-fbc17e1268d1"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 4);

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
    }
}
