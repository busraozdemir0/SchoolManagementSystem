using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Messagetableupdatecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("1e68b53e-104b-4cbb-8f80-7b7d5845a243"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2b556d3d-a5f7-45b4-a756-38a3802c29a6"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a1eccc9c-2418-4dac-b43c-c45d3d1aac8b"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ef385752-c8e7-4ae3-8e67-5183d1326420"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0c74df27-1841-45b0-b6a4-57573143456e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5f53a093-cfdf-4d87-a852-88973f580239"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("60021df5-66d5-4136-8007-1b539d64f781"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("7a21832a-fe27-4fd0-99db-a84ee5ac7dd6"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("924013d3-b629-483a-9526-e168844ece63"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a1171819-fe41-4b30-a2b8-b0492dd84d15"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 367, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 367, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "3ec217a8-7b12-4551-9179-1d9948cd1563");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "206c4c80-c750-453d-b9c2-a55276b9ad36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "f829a856-9fee-45ba-bb7d-2309ed29b22f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "b9045778-614f-4b84-8bb2-3648786f1127");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc395559-845c-44be-aa6d-c1fb6c7054c8", "AQAAAAIAAYagAAAAEGjOyFrOeP6yJHhqfS6YG1D1KX6ocDyUuKLsBsHBlRk+oD9v6CnvFkfQnG0D47Hqug==", "aff5e88c-e982-44a3-8e21-9e40cb17016e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9c18150-ca6c-49c3-b8cc-9aa64ac87651", "AQAAAAIAAYagAAAAEHI0v1UKtK9ceZ12ts+KczMUbBRgjgOU5hMZao3s57S3YGSdzTSRyYyz/U1QctkhdQ==", "1e2f44d9-a863-4198-bc23-7f3de7b09bc4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db20667a-042e-471e-8126-4fc200855440", "AQAAAAIAAYagAAAAEBew+CU4PUNF6ekmjqeSZzIzhbCRKU7zRrEW4GGiFKKlJcbBOgoBZt9c0KGG5Eri9g==", "d87206b8-8a70-412f-b657-cfb43201e631" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("21c906b4-c37a-4822-a3a0-d4381df0f156"), "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(7435), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("658ca76b-7ac1-482a-8fbb-616ea6812b77"), "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(7395), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("786b7023-03d8-42a8-906d-53fb879edf3e"), "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(7447), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("89bcd2c9-6981-4126-93a4-f2cde11ba34e"), "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 617, DateTimeKind.Local).AddTicks(7451), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2f735756-d198-4602-bed8-3d087c3954a1"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8665), null, null, false, null, "Deneme" },
                    { new Guid("3f235fa0-1e2a-45c1-9256-52c153057746"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8707), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("5bf7eae3-2cfe-4310-b3e5-62d1afa05735"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8703), null, null, false, null, "Where can I get some?" },
                    { new Guid("80534c7a-d3b7-4dab-bda9-05daf5441d74"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8701), null, null, false, null, "Lorem İpsum" },
                    { new Guid("86159250-d4ac-4340-9cb2-f906725e3d2e"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8705), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("9963b43c-1a4d-476d-967d-bd37e7ad4d1b"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 25, 13, 16, 31, 618, DateTimeKind.Local).AddTicks(8698), null, null, false, null, "Gelecekte Yapay Zeka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("21c906b4-c37a-4822-a3a0-d4381df0f156"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("658ca76b-7ac1-482a-8fbb-616ea6812b77"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("786b7023-03d8-42a8-906d-53fb879edf3e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("89bcd2c9-6981-4126-93a4-f2cde11ba34e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("2f735756-d198-4602-bed8-3d087c3954a1"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3f235fa0-1e2a-45c1-9256-52c153057746"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5bf7eae3-2cfe-4310-b3e5-62d1afa05735"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("80534c7a-d3b7-4dab-bda9-05daf5441d74"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("86159250-d4ac-4340-9cb2-f906725e3d2e"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("9963b43c-1a4d-476d-967d-bd37e7ad4d1b"));

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 49, 950, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 49, 951, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "5afeb468-1451-4ddb-a86f-268aa4c42f4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "a3cd2a3f-db7d-4dc9-8fc7-eefd48d428b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "e66deb9b-1f80-4dee-87bb-4551d91ed0ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "1fcce9c9-4b38-4aee-a2c1-517d47b83974");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1947a9ab-2b5c-4c1b-b13f-67014edfab8b", "AQAAAAIAAYagAAAAEF9rG1MPkKvwp2QR3jYNIaqo8BquxyE1TZqct0P37xypmehtxjuZ6dceL5HPEVY1uQ==", "636e4ea2-6933-4447-a2bb-3b30a15b6236" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0af6ff1c-2718-40a7-93b8-8294ac87a7a3", "AQAAAAIAAYagAAAAEPTWT3umCE/3YRfjQHtebSMR9Y5lBHKE1lt+QsfyTGjtSVH7Xd6ROb8ylnQ508sbnA==", "7a71cb44-bf41-40c8-a5fe-2308099381e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b7b61bf-8df3-4355-9b1c-4557b02386b0", "AQAAAAIAAYagAAAAEMVeXE5CMhZcSH6IwchllinA5sN8+s+sss5e6jJ4ZaaiA577xIGmcdNrgHprqbgIJw==", "1b32226c-928d-4847-a038-bf3ae05c1d2a" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e68b53e-104b-4cbb-8f80-7b7d5845a243"), "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(8214), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("2b556d3d-a5f7-45b4-a756-38a3802c29a6"), "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(8264), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("a1eccc9c-2418-4dac-b43c-c45d3d1aac8b"), "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(8250), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("ef385752-c8e7-4ae3-8e67-5183d1326420"), "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 211, DateTimeKind.Local).AddTicks(8267), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0c74df27-1841-45b0-b6a4-57573143456e"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5319), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("5f53a093-cfdf-4d87-a852-88973f580239"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5315), null, null, false, null, "Lorem İpsum" },
                    { new Guid("60021df5-66d5-4136-8007-1b539d64f781"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5307), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("7a21832a-fe27-4fd0-99db-a84ee5ac7dd6"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5324), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("924013d3-b629-483a-9526-e168844ece63"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5317), null, null, false, null, "Where can I get some?" },
                    { new Guid("a1171819-fe41-4b30-a2b8-b0492dd84d15"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 25, 13, 8, 50, 212, DateTimeKind.Local).AddTicks(5281), null, null, false, null, "Deneme" }
                });
        }
    }
}
