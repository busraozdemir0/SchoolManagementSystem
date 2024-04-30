using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migcommentupdatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AppUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AppUserId",
                table: "Comment");

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

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comment");

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

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

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

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AppUserId",
                table: "Comment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
