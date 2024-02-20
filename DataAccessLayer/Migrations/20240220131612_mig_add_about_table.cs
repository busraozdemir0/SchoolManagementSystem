using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddabouttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("1cc4f429-ccb1-4bc3-a13f-ef6223cb69cf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("390c1ab2-4313-4be3-82ef-4c0565a177f5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("b54482be-887f-4c00-9088-d137dce95567"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e39691fe-d2cd-47bd-b09b-5e5667cdf8d2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e39c3139-277f-48f0-9642-97c6bacc688c"));

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "Atlas Koleji olarak 2009 yılında başladığımız yolculuğumuzda, ortaokul ve lise öğrencilerimizin başarıya ulaşmasını hedefliyor aynı zamanda hayalindeki lise ve üniversiteleri kazanmaları için elimizden geleni yapıyoruz. Okulda yapılan eğitimin yanı sıra web sitemiz sayesinde konuları pekiştirebilme ve birebir öğretmenle iletişime geçme imkanına sahip olabilecekler. Bu güne kadar mezunlarımızın çoğuna Türkiye'de oldukça ünlü okulları kazanabilmelerine vesile olduk. Hemen siz de iletişime geçin ve uygun fiyatlarla kolejimize kaydolarak hayallerinize ulaşın.", "Çocuğunuz İçin En İyi Seçim Biziz" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "6d92cff1-d9e4-4ba6-83e1-93448abe9f9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "e4c10d91-c14f-498a-ab6a-23aeb6e2b78f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "ca1990c4-85fb-482b-9576-35c3c5b25614");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "50a2ce10-9ef0-4b75-8d76-8fbd6b663cfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "428f4f0f-c225-4cfd-8771-499e78e89a54", "AQAAAAIAAYagAAAAELCXhJlvPqkQlX9i5W3yIcvEh93ZjFUt7l47OF0Nd7hy4CrSVpFcrd7TRRTrTAhsTg==", "89292326-e48b-462d-b932-4fe7c42eb725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bddbf64-8b11-45f5-8574-127237d635b4", "AQAAAAIAAYagAAAAEPw+m7X9QORY7A5sg0S5rkLMRBdmiNYXpVtuJGh/d3gCOpibn5qWqHP9bKe1Vzk4Bg==", "c32a8bf5-cabf-4634-ab3e-f510dc12abeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7abfa9ce-ee70-425a-82c8-2eca029ee5c9", "AQAAAAIAAYagAAAAEPyS8dh/PxIpA0zqzvBNgLfVRftwFkpR2NRJwNrgGyQBv0Oa2TDK/qVb73BsDVTbaA==", "11d624f0-c6a6-4a95-98a2-780ffe32fb8c" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("113470ab-9160-4e28-a7ac-82424e6403af"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("053124fe-8bf4-4592-87cb-f85344cae4f5"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("1e453d97-feaa-43f0-8b94-803c503b7c1a"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("e1400e59-07c3-4cbd-b5bb-1cc257d389bb"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("ef5cb0b6-58bd-4c20-bc4b-9b7e613c76a3"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("113470ab-9160-4e28-a7ac-82424e6403af"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("053124fe-8bf4-4592-87cb-f85344cae4f5"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("1e453d97-feaa-43f0-8b94-803c503b7c1a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e1400e59-07c3-4cbd-b5bb-1cc257d389bb"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ef5cb0b6-58bd-4c20-bc4b-9b7e613c76a3"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "2cb1ba91-4f97-4a04-9914-82e5dbda5268");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "b18ca0ac-53f1-42ab-be1f-f3e631192819");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "aac02758-c7aa-4cc2-9ab8-2030795bb662");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "26d3d05c-1cd6-410b-8e77-fdd72589dbca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfe87037-7ec7-4964-9aa6-2a29ea8d12a7", "AQAAAAIAAYagAAAAEPFtpQ7Vdzzlke1MsB45V0fqyVTi7RWfX7zIM/RxEO6jW+VhO7K6YJxVHwTs1uaH5g==", "73d47cad-485d-43be-ae63-498915622fe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edf01a29-4aa1-4c32-a9a1-45aa7b298c21", "AQAAAAIAAYagAAAAEDsIowTn1R59snJzBNTKl7/e47mj+RoumLy1HbieTMXnPVkTevE31IHXug5RgHS9bQ==", "c561ad39-a7b3-4d54-9a6c-d3593bdb8fa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a71a14-d765-4354-bdc1-7515f3ccb802", "AQAAAAIAAYagAAAAECKbC5SDIOO5aAvhSoYFdokLUVlsgSCgNPIsylD9xydgPk5EZ2gWKwnhT9o76RGxPw==", "17fb25c2-8872-427c-8bf7-705ca0edec8a" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("1cc4f429-ccb1-4bc3-a13f-ef6223cb69cf"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("390c1ab2-4313-4be3-82ef-4c0565a177f5"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("b54482be-887f-4c00-9088-d137dce95567"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("e39691fe-d2cd-47bd-b09b-5e5667cdf8d2"), 2, false, "M102", 5, null, "Matematik", null, null },
                    { new Guid("e39c3139-277f-48f0-9642-97c6bacc688c"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null }
                });
        }
    }
}
