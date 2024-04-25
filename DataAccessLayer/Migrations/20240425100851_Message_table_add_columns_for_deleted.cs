using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Messagetableaddcolumnsfordeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Messages",
                newName: "SenderStatus");

            migrationBuilder.AddColumn<bool>(
                name: "ReceiverIsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiverStatus",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderIsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ReceiverIsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverStatus",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderIsDeleted",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderStatus",
                table: "Messages",
                newName: "IsDeleted");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785140c2-55ee-4a22-8c80-384343c24e89", "AQAAAAIAAYagAAAAEPMQKqvDcYq2PQZSpz6AEWPhZydNbNf42AYLr+eCX5C1cBTjVO2w4XUV5/PF8ArQUw==", "2a39208e-e55b-444c-8802-8db2048a73e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec72922b-a373-434a-a314-77375b5ead65", "AQAAAAIAAYagAAAAEKRndXVBO3EXUD/XBCfkXivQvH0GQ0DVtUjJAbMqYIgE160wUGtl2F5F384RXEBK4Q==", "a0261790-bda1-45f8-9acb-4c4b7d18e82a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ca4666-e8f8-4b5d-ad57-b3b38bca1351", "AQAAAAIAAYagAAAAEM92ZCS96+R3gYtJFB4sRLNA5foDDUUgBB0FkP6bSKsi+iaL/mporh8ePzVdSCZFGQ==", "90eec2c4-a347-4beb-b65b-38ac412e7d42" });

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
    }
}
