using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "b9041179-1b39-4aa1-a7c5-918479bb6082");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "7bd847f2-1964-4914-b882-af2920258b87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "02a15cd1-873d-491c-a0eb-0f8b11d0f3c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "10ec64ac-1437-40db-8fe2-8e2983803275");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c53ad87-c020-4e4d-9521-23e1a46b7cd1", "AQAAAAIAAYagAAAAEKLAMiZms5fSZNoPhSbL5t5Y3m9DiWxOhMquEgHVxu5VlAe0w8Rpn+QF+JG09XOCeA==", "c66fed50-eaf6-4f86-8195-101d5aec6d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3efd2b08-1f61-4e76-8ae9-9390708a2543", "AQAAAAIAAYagAAAAEDTFow+Bxlt5VFHQ3s+YQl86tBZBd4/t0RTYVoDW08CbX2qkMyHN7cIE1tvi/3OInA==", "582f164a-bc83-426f-8b38-367431c25e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1047a1d2-20ae-4044-964d-3324a489f423", "AQAAAAIAAYagAAAAEAmZmeHc3aRlrDEMwkG4Da157K6w/tbkkUeiuCQCOu5R18iAyEX7T1YjnL88DMMA3w==", "b18a7548-9e61-4817-8b52-ed126df0b5b7" });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "DocumentPath", "IsDeleted", "Title" },
                values: new object[] { new Guid("e3d399ad-12ff-455a-9089-f2eb0e7fcafd"), "test", false, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "UserId" },
                values: new object[,]
                {
                    { new Guid("21357f73-d39d-40cd-86f2-d5c59a32e210"), 3, false, "F205", 3, null, "Fizik", null, null },
                    { new Guid("84872d3c-20fb-4b81-b224-4454568269e2"), 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null },
                    { new Guid("9599c5ab-4a16-4688-af7b-79dd0a04ef9b"), 4, false, "B101", 3, null, "Biyoloji", null, null },
                    { new Guid("c43a22c4-6c59-4aaa-8efe-6d627098f4c8"), 2, false, "M102", 5, null, "Matematik", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("e3d399ad-12ff-455a-9089-f2eb0e7fcafd"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("21357f73-d39d-40cd-86f2-d5c59a32e210"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("84872d3c-20fb-4b81-b224-4454568269e2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9599c5ab-4a16-4688-af7b-79dd0a04ef9b"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c43a22c4-6c59-4aaa-8efe-6d627098f4c8"));

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
    }
}
