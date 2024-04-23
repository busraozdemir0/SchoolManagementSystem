using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migmessagetableaddcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3d0883bb-a9fb-4d21-926e-a89a3c097bd6"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("51845db5-1432-4094-88d8-f341789f9b23"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6ff168db-f4f5-4e17-91eb-4c54182ff6ef"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c76b8bfc-579b-4fd6-b824-61a41a964087"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0b01b7eb-d82b-4d51-9d35-3f0b2e250424"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8695636e-9bad-4a19-91df-aa424222f6f0"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b45d0bcb-1ece-4fa9-974d-c53bd8953313"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c307acf5-40e4-4511-b70b-a030904dc095"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d42680f0-6fa9-4e3b-a0ee-50f75cec81fc"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d78829cd-a8b1-4349-bca2-b2b07593423c"));

            migrationBuilder.AddColumn<bool>(
                name: "IsImportant",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 689, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 690, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "c6440c0a-60fb-44de-9e33-2c6e3e6847ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "ad8c4c01-f468-431a-b37a-e149e06f7455");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "6d34d6a9-b733-47ec-b84a-ccef34719094");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "9290310a-9dcb-4c8d-8d30-298ade2c52fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c31cef44-1177-4483-bcf8-c13bcb178bb1", "AQAAAAIAAYagAAAAEFAD6fQNS3keodgvJblxtG3B9SoOp+Sk9nlN9f2BxthXbg2Ua0Rw6gJkAm0s/Zgx0w==", "0810c6d6-8aea-4350-85f7-4de8ae39f1f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "582c33f6-c91a-4bc6-b4c0-9b8fddfeceb3", "AQAAAAIAAYagAAAAEGFO/U86Wmqcd2qx8pWhfMXBCCFFLvyG0BAl/DXbDp/Qci/VLqTkBVE/pJW7KpZVYw==", "0fcd3212-4256-442f-a4b9-f0365609a241" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92f39990-0a3e-47ec-8672-342628bc391c", "AQAAAAIAAYagAAAAEPbsttLfQxKG4+23eIpePL/2GhWcrWfgFqZS/M7TXWNkqfMwLHz6b/zgf9pfufu06A==", "e806f9f5-8885-4c6b-9e39-38bd392db7b7" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 959, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 959, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 959, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 13, 57, 7, 959, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("17e54b74-c63a-4f11-86b3-500a76c7c2a4"), "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(991), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6ccb5723-4f9e-4733-96d1-88bce3911af8"), "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(941), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("7a722e8c-5098-4879-9199-3521e51357be"), "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(987), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("bd76296b-67e7-41b3-95dd-0bbea054c95b"), "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(995), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("34448b8f-4420-4204-8f18-5c625a8412ad"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8642), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("5557434d-be67-42e2-8fd4-b6f51b5a3a96"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8614), null, null, false, null, "Deneme" },
                    { new Guid("a562eb37-b600-4b57-9b19-ac7b93c88ce1"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8656), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("ab04760d-d655-42d3-9261-7ec61c3a8729"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8654), null, null, false, null, "Where can I get some?" },
                    { new Guid("ac062dec-5281-40d8-b4c1-9ab7b9823c59"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8664), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("e9748851-d09b-447d-9e4b-4256fd8f3520"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 13, 57, 7, 960, DateTimeKind.Local).AddTicks(8652), null, null, false, null, "Lorem İpsum" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("17e54b74-c63a-4f11-86b3-500a76c7c2a4"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6ccb5723-4f9e-4733-96d1-88bce3911af8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("7a722e8c-5098-4879-9199-3521e51357be"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bd76296b-67e7-41b3-95dd-0bbea054c95b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("34448b8f-4420-4204-8f18-5c625a8412ad"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5557434d-be67-42e2-8fd4-b6f51b5a3a96"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a562eb37-b600-4b57-9b19-ac7b93c88ce1"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ab04760d-d655-42d3-9261-7ec61c3a8729"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ac062dec-5281-40d8-b4c1-9ab7b9823c59"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e9748851-d09b-447d-9e4b-4256fd8f3520"));

            migrationBuilder.DropColumn(
                name: "IsImportant",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 56, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 56, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "ebc4335d-372d-40d1-954c-65674e5ffe8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "872cd129-d935-4f31-bdc9-e5ef974cd38f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "5fcb8ce9-9b89-41ba-8a25-f26f74b76c69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "5c669c5f-0e86-4101-bd43-108a9d122fc6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51396677-cc7e-4911-837c-8a51945fa498", "AQAAAAIAAYagAAAAELvPFeOGSwCfR/lpNyIyspYsrovVurGcmauO80C9RGXBzcp70bgSNQmVokS/sCzw8w==", "68a3d6a3-789b-4d26-bf72-ea4b2da8c532" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "432671db-8b38-4fac-af6f-22fcba411674", "AQAAAAIAAYagAAAAEBtSyE2Tf+X1Jsyr8pFRiUFXsNtFF4qekNdvGphTkrnVzks4LgxTBvRpNNFx52F/vA==", "a7b3cdb8-91fe-4a94-a662-5c9d07f882db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d7ce62-f6f9-4bfb-89d2-3d7adfa16446", "AQAAAAIAAYagAAAAEMsjH2XpvLP1bD4EnD10ioPh71aalWn6ptwKGf3NM5pB3wcCFUjt54nFSU+oHdUoTA==", "8a3706c9-04ff-43a5-9431-07bf34246090" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("3d0883bb-a9fb-4d21-926e-a89a3c097bd6"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9141), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("51845db5-1432-4094-88d8-f341789f9b23"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9095), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6ff168db-f4f5-4e17-91eb-4c54182ff6ef"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9134), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("c76b8bfc-579b-4fd6-b824-61a41a964087"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9138), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0b01b7eb-d82b-4d51-9d35-3f0b2e250424"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5517), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("8695636e-9bad-4a19-91df-aa424222f6f0"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5476), null, null, false, null, "Deneme" },
                    { new Guid("b45d0bcb-1ece-4fa9-974d-c53bd8953313"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5502), null, null, false, null, "Where can I get some?" },
                    { new Guid("c307acf5-40e4-4511-b70b-a030904dc095"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5492), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("d42680f0-6fa9-4e3b-a0ee-50f75cec81fc"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5525), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("d78829cd-a8b1-4349-bca2-b2b07593423c"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5500), null, null, false, null, "Lorem İpsum" }
                });
        }
    }
}
