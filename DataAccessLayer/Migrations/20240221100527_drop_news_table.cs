using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dropnewstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

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
                value: "0ae01bfb-25b4-49b6-bac2-94b04dd77685");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "1b4f8694-75ba-4dd2-8c10-77408e7bfd5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "dc7250df-edf6-4b3f-812c-486afbb987a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "91573747-5143-42b4-8d5a-6495f36787d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f80069d-7362-4ea3-a348-80fcd3c309bf", "AQAAAAIAAYagAAAAEKE7PSp/lwTaxK6DM3df8HI13Kh1GYJIM/g5jzR3j2GOOWFefahjYRubfrCECPr09A==", "136a997b-f5b6-42e2-a584-ce06b990fbd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc666b96-f8d4-4822-9a25-102e8e69e285", "AQAAAAIAAYagAAAAEGZOEoj80JCiVV9fMft7sHvbH5Vhyswib5Cuc2N8ZZvi3eoQLWCkwSLAH4mZiSSgOg==", "5a7c0825-b507-4eaf-811d-8f9819c26221" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8be7c251-38df-40b6-bab8-42f918086bc5", "AQAAAAIAAYagAAAAEHL7Zopwz0yVgVdxt9kgiOa4dfT2AuUgzW4yJy7JOBNq1hj44Lyy9ccjXgonOv8Qcg==", "1385f60b-edd5-4d4b-b38a-e3c8a5b51517" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("b853d7ad-6a06-42c3-ae17-a9f6b349be6f"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a3ead9b-cac4-44f6-bf86-967b54ea6bbf"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null },
                    { new Guid("14c3f38f-3b57-4ea2-a859-603bf4d59256"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("3d591580-2efe-44af-a983-ca9a32923246"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("ce4e916e-5590-48ac-a016-b86808d682e8"), 2, false, "M102", 5, null, "Matematik", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("b853d7ad-6a06-42c3-ae17-a9f6b349be6f"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0a3ead9b-cac4-44f6-bf86-967b54ea6bbf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("14c3f38f-3b57-4ea2-a859-603bf4d59256"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3d591580-2efe-44af-a983-ca9a32923246"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ce4e916e-5590-48ac-a016-b86808d682e8"));

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

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
    }
}
