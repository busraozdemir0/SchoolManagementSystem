using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddimagetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Reports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Reports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NewsLetters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "NewsLetters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "NewsLetters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NewsLetters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "NewsLetters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LessonVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LessonVideos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "LessonVideos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "LessonVideos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LessonScores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LessonScores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "LessonScores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LessonScores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "LessonScores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LessonDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LessonDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "LessonDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "LessonDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Announcements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Announcements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Announcements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 27, 13, 33, 21, 684, DateTimeKind.Local).AddTicks(3236), null, false, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "ef264b6b-3797-422c-8e62-85139285bc20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "080673e9-fde1-42f8-8463-1f9e1b76780d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "0f30a2e8-2a0d-4bfd-87c0-677e8828f869");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "38158031-322b-4412-affe-a3ff0b1de05a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22158098-41fe-441e-8de5-cbf4b409cd20", null, "AQAAAAIAAYagAAAAEJLuH287uN114Ac+oeHYlz9Z8q+HVyFjIobXiY2AluDyXrRCjZlPAZaw/eGvNiGfjQ==", "a84943a6-175f-49c7-a9be-289142dde6a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa8ac22d-05d2-4d4d-a4c4-6a28ed10e4e0", null, "AQAAAAIAAYagAAAAEH1OrJHq+zDnT4lWrB3+1vOe9Le6C5Tj6i0gJ0NWUHQkG+dJ7xwlHCAE8uqdysRG1g==", "240af4a3-bc2d-4395-afe3-4a0cc3cbd056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "ImageId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7de5e980-0a1a-4add-b24d-5aeb7fd1f9c7", null, "AQAAAAIAAYagAAAAELxEKhP0a839a/NHLVzGngcimtO44PfatDwT0d2EI+oBdcLsTV7TpuxB7RN1ctBUgw==", "4aa46cae-c428-4e14-a6fa-c4f9a2053e9a" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1561), null, false, null });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1585), null, false, null });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1586), null, false, null });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1587), null, false, null });

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("e57d6a25-e02c-4a0f-9163-25f28d022460"), "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(3773), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("68119be2-2a25-471d-b898-4d3e40e12403"), "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(5909), null, 2, false, "M102", 5, null, "Matematik", null, null, null },
                    { new Guid("9d58e6ed-cc3d-40f4-bb6b-2c267f9d4630"), "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(5920), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("bde0b5ba-eea7-4aaf-a9d2-80ddff9e949d"), "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(5918), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("c55aa0a0-06b2-4399-b4ee-de8f5cdea853"), "Undefined", new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(5891), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ImageId",
                table: "Reports",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Images_ImageId",
                table: "Reports",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Images_ImageId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ImageId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("e57d6a25-e02c-4a0f-9163-25f28d022460"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("68119be2-2a25-471d-b898-4d3e40e12403"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9d58e6ed-cc3d-40f4-bb6b-2c267f9d4630"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bde0b5ba-eea7-4aaf-a9d2-80ddff9e949d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c55aa0a0-06b2-4399-b4ee-de8f5cdea853"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "NewsLetters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "LessonVideos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LessonScores");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LessonScores");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "LessonScores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LessonScores");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "LessonScores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LessonDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LessonDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "LessonDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "LessonDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Abouts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
                columns: new[] { "ConcurrencyStamp", "ImagePath", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c53ad87-c020-4e4d-9521-23e1a46b7cd1", null, "AQAAAAIAAYagAAAAEKLAMiZms5fSZNoPhSbL5t5Y3m9DiWxOhMquEgHVxu5VlAe0w8Rpn+QF+JG09XOCeA==", "c66fed50-eaf6-4f86-8195-101d5aec6d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "ImagePath", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3efd2b08-1f61-4e76-8ae9-9390708a2543", null, "AQAAAAIAAYagAAAAEDTFow+Bxlt5VFHQ3s+YQl86tBZBd4/t0RTYVoDW08CbX2qkMyHN7cIE1tvi/3OInA==", "582f164a-bc83-426f-8b38-367431c25e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "ImagePath", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1047a1d2-20ae-4044-964d-3324a489f423", null, "AQAAAAIAAYagAAAAEAmZmeHc3aRlrDEMwkG4Da157K6w/tbkkUeiuCQCOu5R18iAyEX7T1YjnL88DMMA3w==", "b18a7548-9e61-4817-8b52-ed126df0b5b7" });

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
    }
}
