using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addtableLessonVideoVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "LessonVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonVideoVisitors",
                columns: table => new
                {
                    LessonVideoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonVideoVisitors", x => new { x.LessonVideoId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_LessonVideoVisitors_LessonVideos_LessonVideoId",
                        column: x => x.LessonVideoId,
                        principalTable: "LessonVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonVideoVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 13, 22, 6, 7, 636, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MapLocation" },
                values: new object[] { new DateTime(2024, 4, 13, 22, 6, 7, 637, DateTimeKind.Local).AddTicks(281), "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12062.0903918608!2d31.180443!3d40.904286!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409da0c35c97aa71%3A0x93cc0b0387c8fc40!2zRMO8emNlIMOcbml2ZXJzaXRlc2kgTcO8aGVuZGlzbGlrIEZha8O8bHRlc2k!5e0!3m2!1str!2str!4v1711622193416!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "36d11c49-4ea9-4f78-aeb1-c31db9ccc8b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "764fb919-f254-4234-98b7-14f87f6ab638");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "0f916fda-e073-42d1-bc86-6c9efacc7ae7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "3a9cccd5-06d7-4d34-980e-011e115d61b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "b4c8b5dc-d887-4bbf-8b13-e12d666ad35c", "AQAAAAIAAYagAAAAEObyGU7hznNPazfd7RHsXKFBrhL2Gd0mt/zGVpfERM/uTiG52nlUYvpOG3BIQkON5w==", "(222) 222 2222", "8e9216ff-8827-470c-b945-66aa2df7d425" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6e451588-5e79-40e6-b474-55733ad8b8a3", "AQAAAAIAAYagAAAAEI+vlGSbuLQHpaSwn5pzicxViMHtULVHmfkYF//8kmqk9zGmtKufPcBhPlLA/kz87w==", "(111) 111 1111", "ac361773-66f5-4b3c-b996-4314247e9230" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "5d4903cb-57b8-4f86-9dc0-980028874bc2", "AQAAAAIAAYagAAAAEJM48+JyV8orWKtwCbiNMr+b7cGb6xTm0ApFYvUq+xJ6mACw4u0o3XpMmhJqgYepRw==", "(333) 333 3333", "7a84faec-5f7c-4893-9933-50b15c47b39c" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c6be6d1-58d7-4761-a3fe-222fd75c27b9"), "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(4911), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("0e712d9a-8d88-4f37-9bd9-83ad0b5615d0"), "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(4904), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("ecb68e10-f444-4090-9d5b-60fa73b2503f"), "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(4864), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("f502d33f-283a-4257-8310-bbe281310a47"), "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 882, DateTimeKind.Local).AddTicks(4908), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2a81b003-14b6-4414-aaae-1ab59295c952"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5347), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("56c363ea-b61c-4a67-9002-0d38c2a335b2"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5349), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("64d7be14-440e-4e4b-a773-fec6749b3102"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5308), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("82ab0bb1-2c9b-47ad-a516-d709d671e5ad"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5310), null, null, false, null, "Lorem İpsum" },
                    { new Guid("ceaaaa0e-e115-4f9c-9edd-10b976c05f90"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5273), null, null, false, null, "Deneme" },
                    { new Guid("e9196b12-06e9-49e0-a12a-7ee17fd145ce"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 13, 22, 6, 7, 883, DateTimeKind.Local).AddTicks(5345), null, null, false, null, "Where can I get some?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonVideoVisitors_VisitorId",
                table: "LessonVideoVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonVideoVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0c6be6d1-58d7-4761-a3fe-222fd75c27b9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0e712d9a-8d88-4f37-9bd9-83ad0b5615d0"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ecb68e10-f444-4090-9d5b-60fa73b2503f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f502d33f-283a-4257-8310-bbe281310a47"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("2a81b003-14b6-4414-aaae-1ab59295c952"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("56c363ea-b61c-4a67-9002-0d38c2a335b2"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("64d7be14-440e-4e4b-a773-fec6749b3102"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("82ab0bb1-2c9b-47ad-a516-d709d671e5ad"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ceaaaa0e-e115-4f9c-9edd-10b976c05f90"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("e9196b12-06e9-49e0-a12a-7ee17fd145ce"));

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "LessonVideos");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "dc13865e-36de-4f83-8253-7ccd2e7ce4b4", "AQAAAAIAAYagAAAAEI25q7MfvI4Np2V8GfqLq8EOqhHwTePV6erdOK5riZ8OTU/DsU4MkWNdNhfRHEyt3g==", "+902222222222", "9398a3d6-491d-4713-8b05-1325f96d81f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d221a682-88da-4894-9c31-8b85c3eaba81", "AQAAAAIAAYagAAAAEPcPiriDxer9x7lE6juL7VqC+EA9Kj3+Q1iFf9Lt4lhTHoEy5Vp3PDlLuBJBsrv7cg==", "+901111111111", "a6f029bd-164c-4b53-9f58-2650cd02a8ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d20ed421-efcc-4a96-9250-a115a4af0942", "AQAAAAIAAYagAAAAEEDk1nnor+tyAVuWLI2Msj/ZCsMuv9cesE3LJRFMW9FeE56Jmq3LBdEoWkvBvznFcA==", "+903333333333", "de8e2d0f-9f6b-4a64-a085-14883b26c25d" });

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
    }
}
