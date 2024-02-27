using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class aboutimageadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Abouts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageId" },
                values: new object[] { new DateTime(2024, 2, 27, 14, 50, 2, 824, DateTimeKind.Local).AddTicks(3231), null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "50bc3a61-5cca-41fd-8aee-2307d104dcf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "d838bfb0-dba7-453a-b3fc-fbbbc20d63dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "91e3a231-5563-4089-bccc-f4d6c171015f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "8405387e-7a57-411d-bb58-b09b05925918");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86dca315-5082-44f9-b78d-b3f2174d6c42", "AQAAAAIAAYagAAAAEMYWcwdVfrvNAJqJ9ozZItpXK3IGDpwW6BtxUzzv/F2lJxuzMgxW4DQZFmMJZUeT8w==", "db8a9046-ae97-4439-b226-0b055750066c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8979283-0795-4d78-81ae-694b1be393ed", "AQAAAAIAAYagAAAAEMFonqzBdI7mJSvN0/kKTUXNkPApOh8YWBOV41IQ0PijdkzgeYRrG6+Qaf6L85RMGg==", "67f3ebdd-60b0-4601-9044-f1f6f406c9d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4544bb-afd4-46f4-87ca-72269713af52", "AQAAAAIAAYagAAAAEHYOdwGzC/riayI/FqWACda3Wj8AL1AzoRIPkKavtOwhFkiyT4I8y77VWKvUlq04Kg==", "0baf6893-e0f3-4e00-bb65-3edc47b1ae66" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 14, 50, 3, 80, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("49551ea5-5729-4ffa-99b4-a40a83561e4a"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(84), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d48970d-bfbb-4c2f-a9a8-dee3426b6970"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3052), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("2c9c26f1-9f9d-4443-be85-00cd6e712541"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3057), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("a56eaab7-00ad-49bc-ad4a-3d083fbde5de"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3004), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("eb72fb64-2e0a-474f-9066-ebb8d577801e"), "Undefined", new DateTime(2024, 2, 27, 14, 50, 3, 81, DateTimeKind.Local).AddTicks(3044), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_ImageId",
                table: "Abouts",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Images_ImageId",
                table: "Abouts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Images_ImageId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_ImageId",
                table: "Abouts");

            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("49551ea5-5729-4ffa-99b4-a40a83561e4a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0d48970d-bfbb-4c2f-a9a8-dee3426b6970"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("2c9c26f1-9f9d-4443-be85-00cd6e712541"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a56eaab7-00ad-49bc-ad4a-3d083fbde5de"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("eb72fb64-2e0a-474f-9066-ebb8d577801e"));

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Abouts");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 13, 33, 21, 684, DateTimeKind.Local).AddTicks(3236));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22158098-41fe-441e-8de5-cbf4b409cd20", "AQAAAAIAAYagAAAAEJLuH287uN114Ac+oeHYlz9Z8q+HVyFjIobXiY2AluDyXrRCjZlPAZaw/eGvNiGfjQ==", "a84943a6-175f-49c7-a9be-289142dde6a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa8ac22d-05d2-4d4d-a4c4-6a28ed10e4e0", "AQAAAAIAAYagAAAAEH1OrJHq+zDnT4lWrB3+1vOe9Le6C5Tj6i0gJ0NWUHQkG+dJ7xwlHCAE8uqdysRG1g==", "240af4a3-bc2d-4395-afe3-4a0cc3cbd056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7de5e980-0a1a-4add-b24d-5aeb7fd1f9c7", "AQAAAAIAAYagAAAAELxEKhP0a839a/NHLVzGngcimtO44PfatDwT0d2EI+oBdcLsTV7TpuxB7RN1ctBUgw==", "4aa46cae-c428-4e14-a6fa-c4f9a2053e9a" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 27, 13, 33, 22, 34, DateTimeKind.Local).AddTicks(1587));

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
        }
    }
}
