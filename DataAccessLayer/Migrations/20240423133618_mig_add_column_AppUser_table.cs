using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddcolumnAppUsertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 126, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 126, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "be40eb3a-042e-4b5b-ab2b-bc7c2eb3bac3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "88a7cef6-e881-48dd-9433-9b0c516797a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "a4d6eb89-c533-448f-9613-09f4057901a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "088cf29e-878d-4067-aea6-f8657a539e69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785140c2-55ee-4a22-8c80-384343c24e89", false, "AQAAAAIAAYagAAAAEPMQKqvDcYq2PQZSpz6AEWPhZydNbNf42AYLr+eCX5C1cBTjVO2w4XUV5/PF8ArQUw==", "2a39208e-e55b-444c-8802-8db2048a73e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec72922b-a373-434a-a314-77375b5ead65", false, "AQAAAAIAAYagAAAAEKRndXVBO3EXUD/XBCfkXivQvH0GQ0DVtUjJAbMqYIgE160wUGtl2F5F384RXEBK4Q==", "a0261790-bda1-45f8-9acb-4c4b7d18e82a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ca4666-e8f8-4b5d-ad57-b3b38bca1351", false, "AQAAAAIAAYagAAAAEM92ZCS96+R3gYtJFB4sRLNA5foDDUUgBB0FkP6bSKsi+iaL/mporh8ePzVdSCZFGQ==", "90eec2c4-a347-4beb-b65b-38ac412e7d42" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 406, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 406, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 406, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 16, 36, 18, 406, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("11c77d2d-9791-4eb5-bbbc-fe6b28d8331d"), "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(1003), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("279e3edd-d2d6-43a0-967c-5a9ed29cb297"), "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(947), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6a07355a-d765-46eb-8df2-d8fbbc6c9c64"), "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(991), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("efe5eacf-0c09-4579-9e87-052d1db8f858"), "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(987), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5c4f2064-b7c2-4234-80dd-26a7f72286f5"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8800), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("93e3424b-a680-45a2-a845-ae4ff1ee1503"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8798), null, null, false, null, "Where can I get some?" },
                    { new Guid("95b47c05-c22a-4666-ba58-c98dafcc13ea"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8796), null, null, false, null, "Lorem İpsum" },
                    { new Guid("a1dd47d5-407a-4759-8668-f7807563bfc9"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8805), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("a353efe9-42e2-4229-b6a2-78f5d51d2448"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8767), null, null, false, null, "Deneme" },
                    { new Guid("f52f0084-2b7e-4028-a9af-69e7ce129651"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 23, 16, 36, 18, 407, DateTimeKind.Local).AddTicks(8788), null, null, false, null, "Gelecekte Yapay Zeka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("11c77d2d-9791-4eb5-bbbc-fe6b28d8331d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("279e3edd-d2d6-43a0-967c-5a9ed29cb297"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6a07355a-d765-46eb-8df2-d8fbbc6c9c64"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("efe5eacf-0c09-4579-9e87-052d1db8f858"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("5c4f2064-b7c2-4234-80dd-26a7f72286f5"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("93e3424b-a680-45a2-a845-ae4ff1ee1503"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("95b47c05-c22a-4666-ba58-c98dafcc13ea"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a1dd47d5-407a-4759-8668-f7807563bfc9"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("a353efe9-42e2-4229-b6a2-78f5d51d2448"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("f52f0084-2b7e-4028-a9af-69e7ce129651"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

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
    }
}
