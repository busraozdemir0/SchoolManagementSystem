using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddcommenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 198, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 198, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "a0732b2c-c94f-4ed7-b2ab-98b3a4fcaf92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "04280373-0113-426b-b1ab-9b25d3b7be3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "954ad776-3a9e-4fe6-93b0-9ca520e37c3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "5c371ec1-ac4d-40ab-afc0-308b5a1ac835");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "437e3c8a-ec40-42d8-bd8d-6667d660c31a", "AQAAAAIAAYagAAAAENQOGoeG2t03rSGrpaSa7+tX+8hd5CENm1RUT4OCvA+zwJKlaY6YRVrCX58tAJD2Rg==", "b6c1a24a-5dcc-44c2-8112-94b426502ef8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b23cbbb-162b-424b-ba15-4b7d24970878", "AQAAAAIAAYagAAAAEIpOq6Bkh/1hZrobLZcyrP5qr/R5q01T0Vq8FNxuv09w2kbEJ9NPaY6AnarBVMuhzQ==", "bf359453-4d9b-45b7-92a1-d907050ef91e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45fd1ec9-9c6e-4af5-a710-85c5401d0c27", "AQAAAAIAAYagAAAAENk5Q4OS8elc1fMf4/5Q6cyn4ZlrumGviwG1o4K/BTyVlsI2isQT/gHqgZQpyRfryQ==", "a8930166-7c9e-4aea-8499-7b847ba6c482" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("997e2049-55b8-4a85-a38e-f7376e69cdae"), "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(9764), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("bb3f8029-d5d8-450a-b91b-1947ebf19650"), "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(9715), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("cb819499-389e-48ec-be15-8b39a5f9f1d3"), "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(9760), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("ce14f932-0e37-4d6a-82c8-869d0b8acdb4"), "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 479, DateTimeKind.Local).AddTicks(9768), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("57028372-e2c9-40c5-a484-7b704ed8601a"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6936), null, null, false, null, "Lorem İpsum" },
                    { new Guid("60df88cb-f2d4-4c86-b454-7e1330540490"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6912), null, null, false, null, "Deneme" },
                    { new Guid("6852be28-1189-4703-8265-c0ffb80997b0"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6938), null, null, false, null, "Where can I get some?" },
                    { new Guid("77e59bac-5a51-43ea-adb1-84799cbf13fd"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6928), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("b4c7d40b-2609-4d89-821b-c94315f3c20b"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6952), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("c4dc378a-320d-464a-bd79-a32fbf384cbb"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 30, 13, 18, 32, 480, DateTimeKind.Local).AddTicks(6962), null, null, false, null, "Bir Ödül Daha Kazandık" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AppUserId",
                table: "Comment",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("997e2049-55b8-4a85-a38e-f7376e69cdae"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bb3f8029-d5d8-450a-b91b-1947ebf19650"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("cb819499-389e-48ec-be15-8b39a5f9f1d3"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ce14f932-0e37-4d6a-82c8-869d0b8acdb4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("57028372-e2c9-40c5-a484-7b704ed8601a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("60df88cb-f2d4-4c86-b454-7e1330540490"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("6852be28-1189-4703-8265-c0ffb80997b0"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("77e59bac-5a51-43ea-adb1-84799cbf13fd"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b4c7d40b-2609-4d89-821b-c94315f3c20b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c4dc378a-320d-464a-bd79-a32fbf384cbb"));

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
    }
}
