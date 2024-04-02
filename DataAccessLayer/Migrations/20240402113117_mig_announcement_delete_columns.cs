using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migannouncementdeletecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "StudentStatusView",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "TeacherStatusView",
                table: "Announcements");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 14, 31, 17, 208, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MapLocation" },
                values: new object[] { new DateTime(2024, 4, 2, 14, 31, 17, 208, DateTimeKind.Local).AddTicks(7811), "\"https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12062.0903918608!2d31.180443!3d40.904286!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409da0c35c97aa71%3A0x93cc0b0387c8fc40!2zRMO8emNlIMOcbml2ZXJzaXRlc2kgTcO8aGVuZGlzbGlrIEZha8O8bHRlc2k!5e0!3m2!1str!2str!4v1711622193416!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "3bcda526-967c-4c18-9c08-2d5465e8c604");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "e7954d7d-3979-4304-ab2c-171654dbbc64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "4b3db0b4-ae2c-4cb6-a1bd-40477ce1c5e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "39757716-34cd-4277-bdde-6ddba377511a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc13865e-36de-4f83-8253-7ccd2e7ce4b4", "AQAAAAIAAYagAAAAEI25q7MfvI4Np2V8GfqLq8EOqhHwTePV6erdOK5riZ8OTU/DsU4MkWNdNhfRHEyt3g==", "9398a3d6-491d-4713-8b05-1325f96d81f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d221a682-88da-4894-9c31-8b85c3eaba81", "AQAAAAIAAYagAAAAEPcPiriDxer9x7lE6juL7VqC+EA9Kj3+Q1iFf9Lt4lhTHoEy5Vp3PDlLuBJBsrv7cg==", "a6f029bd-164c-4b53-9f58-2650cd02a8ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20ed421-efcc-4a96-9250-a115a4af0942", "AQAAAAIAAYagAAAAEEDk1nnor+tyAVuWLI2Msj/ZCsMuv9cesE3LJRFMW9FeE56Jmq3LBdEoWkvBvznFcA==", "de8e2d0f-9f6b-4a64-a085-14883b26c25d" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b51f19d-9d9a-4275-917d-fa6f2d7b5dff"), "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(8373), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("bfa68c0f-e40f-4c1d-bf6c-45272ff28d29"), "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(8417), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("d30486f4-2191-4a0e-88b5-61a948e6aa80"), "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(8421), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("dc479486-335c-4402-9744-986db173764f"), "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(8424), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("12048f93-d53e-4e3a-83a1-8e71cdc27b08"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9915), null, null, false, null, "Where can I get some?" },
                    { new Guid("23cfe938-c233-4add-a6ee-fbc774be9972"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9872), null, null, false, null, "Deneme" },
                    { new Guid("6bbc6abd-5d67-4b1a-9e7f-bfc890abde26"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9912), null, null, false, null, "Lorem İpsum" },
                    { new Guid("774a6833-8e8d-4a53-8adc-5f4336faffb4"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9917), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("81063dfc-1647-42e4-b42c-8afaa0e23f3c"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9924), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("ee9cfb67-088a-4549-b61d-b629fed53046"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 2, 14, 31, 17, 474, DateTimeKind.Local).AddTicks(9884), null, null, false, null, "Gelecekte Yapay Zeka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("5b51f19d-9d9a-4275-917d-fa6f2d7b5dff"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bfa68c0f-e40f-4c1d-bf6c-45272ff28d29"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d30486f4-2191-4a0e-88b5-61a948e6aa80"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("dc479486-335c-4402-9744-986db173764f"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("12048f93-d53e-4e3a-83a1-8e71cdc27b08"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("23cfe938-c233-4add-a6ee-fbc774be9972"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("6bbc6abd-5d67-4b1a-9e7f-bfc890abde26"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("774a6833-8e8d-4a53-8adc-5f4336faffb4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("81063dfc-1647-42e4-b42c-8afaa0e23f3c"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ee9cfb67-088a-4549-b61d-b629fed53046"));

            migrationBuilder.AddColumn<bool>(
                name: "StudentStatusView",
                table: "Announcements",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TeacherStatusView",
                table: "Announcements",
                type: "bit",
                nullable: true);

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
                columns: new[] { "CreatedDate", "MapLocation" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 51, 58, 878, DateTimeKind.Local).AddTicks(4464), "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12062.0903918608!2d31.180443!3d40.904286!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409da0c35c97aa71%3A0x93cc0b0387c8fc40!2zRMO8emNlIMOcbml2ZXJzaXRlc2kgTcO8aGVuZGlzbGlrIEZha8O8bHRlc2k!5e0!3m2!1str!2str!4v1711622193416!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade" });

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
        }
    }
}
