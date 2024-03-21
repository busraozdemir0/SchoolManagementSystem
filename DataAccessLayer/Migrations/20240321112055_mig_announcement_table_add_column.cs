using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migannouncementtableaddcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("1db46334-288a-4da7-a134-2b8f486666a9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("01897875-59a9-4634-abe1-3217a135b313"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0b221aa4-d56c-4475-be80-8e725e6aefc2"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("95721574-3741-4b62-a05f-9c66cf2c84c3"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("9901f11e-f7f1-409e-83af-11669d34948b"));

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
                value: new DateTime(2024, 3, 21, 14, 20, 55, 121, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "640e0b2c-5972-487c-a42a-713094901046");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "18eec6a4-479a-4a86-8d7d-191188f08888");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "a0088d35-36aa-40c3-8691-719ea6d74399");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "078458d0-b73b-418c-b604-cd4a1d914578");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22988a65-b352-4a51-a231-8d8f83b5d96e", "AQAAAAIAAYagAAAAEFA0/yKgyGnBqHTbCB+NJbIODf9ZkPjzqMl+18f0emI8J+uIGFe9UNz/DDWx59L86w==", "69771d63-2611-4f79-93e0-4de2cb14d07b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b00b60a9-71ff-4dab-9d5b-a10eae4c9233", "AQAAAAIAAYagAAAAEOqypQ2ihcmCrsJkiVWjt4VtHd15ktQBfEpJAB6b37o7ik10S+53jqr6yeGwlZFDUw==", "bd60f2f7-d20e-491d-9ddf-ccbe19f22c6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d92f9db1-88fc-4fca-afde-5c3332905767", "AQAAAAIAAYagAAAAEGy1AvIJnhdVFOsk+8/Q9V+QW+6WmQlTppwRxG3a6iYjRfbF16VpS/4UJvdDUK4bRQ==", "a264dacd-cac5-4dfc-8d66-0c1bbef17bf1" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 21, 14, 20, 55, 364, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("d17d88ff-5fc9-49ce-b5f7-1cbd34bc402d"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(1669), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("282a3823-c496-4b5a-a8a4-9de392a13f2e"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3330), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("891c1a25-5374-4740-ae15-1e3b3023bfde"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3333), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("8a8fe24a-1c80-4a47-8dff-11c6748b112e"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3312), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("d37875e4-d2a3-4d1e-b3c5-8031c7bfbad1"), "Undefined", new DateTime(2024, 3, 21, 14, 20, 55, 365, DateTimeKind.Local).AddTicks(3327), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("d17d88ff-5fc9-49ce-b5f7-1cbd34bc402d"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("282a3823-c496-4b5a-a8a4-9de392a13f2e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("891c1a25-5374-4740-ae15-1e3b3023bfde"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8a8fe24a-1c80-4a47-8dff-11c6748b112e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d37875e4-d2a3-4d1e-b3c5-8031c7bfbad1"));

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
                value: new DateTime(2024, 3, 15, 23, 37, 18, 901, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "54119ee1-cc1f-4897-bd3b-838905f38617");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "2f2581e6-5648-46f3-bd64-c744d9ef2a5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "1c07b258-ce3e-42c7-8db1-732c7538a174");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "ecabdb37-96e3-4ec2-8637-da137a0d7a54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba7e2302-7bee-45c6-a389-e74919958d50", "AQAAAAIAAYagAAAAEK6nMZceZ69qtafzH3sJ1nKms81To5FF02YYuhfQA0uOx4TW22aJlvicEvrcTBmhbQ==", "3808a1dc-df8e-4751-a058-c639552126fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfba86b8-e032-48b0-9eb9-77e9010da302", "AQAAAAIAAYagAAAAEFSRA5BaLgFAh1I/TtxD5FyQYHhQ7+R9GWrnxd4pzMn9m0AFzgcy6pZJYsEFeF+BjA==", "98851b7d-743d-49c7-bbe9-40665687fa3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d8b032-1300-4a9c-9f0b-6705ca847f3b", "AQAAAAIAAYagAAAAEMIm+Na0CZohtloKpuexuWBimogJ7V0RbdpO5BtMUBwPfI6Ds1f0tgTXd95KM43ARQ==", "1a98ff7b-42d3-4a02-93f3-6e288378aedc" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 23, 37, 19, 146, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 23, 37, 19, 146, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 23, 37, 19, 146, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 23, 37, 19, 146, DateTimeKind.Local).AddTicks(8934));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("1db46334-288a-4da7-a134-2b8f486666a9"), "Undefined", new DateTime(2024, 3, 15, 23, 37, 19, 147, DateTimeKind.Local).AddTicks(673), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("01897875-59a9-4634-abe1-3217a135b313"), "Undefined", new DateTime(2024, 3, 15, 23, 37, 19, 147, DateTimeKind.Local).AddTicks(2403), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("0b221aa4-d56c-4475-be80-8e725e6aefc2"), "Undefined", new DateTime(2024, 3, 15, 23, 37, 19, 147, DateTimeKind.Local).AddTicks(2401), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("95721574-3741-4b62-a05f-9c66cf2c84c3"), "Undefined", new DateTime(2024, 3, 15, 23, 37, 19, 147, DateTimeKind.Local).AddTicks(2383), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("9901f11e-f7f1-409e-83af-11669d34948b"), "Undefined", new DateTime(2024, 3, 15, 23, 37, 19, 147, DateTimeKind.Local).AddTicks(2399), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }
    }
}
