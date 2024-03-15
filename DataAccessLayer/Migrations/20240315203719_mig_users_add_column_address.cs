using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migusersaddcolumnaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonDocuments",
                keyColumn: "Id",
                keyValue: new Guid("5dc921f3-0a71-47a8-abcd-77f913a0525c"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("45faf426-7593-47f8-b924-644284e88376"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("99f26f35-8bd0-4bcb-8326-73ec522983c0"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("bda4a05f-778a-41f6-8dc0-1213e3074772"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f642e262-f9e4-454c-b32d-68170b3d29ef"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54119ee1-cc1f-4897-bd3b-838905f38617", "Öğrenci", "ÖĞRENCI" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f2581e6-5648-46f3-bd64-c744d9ef2a5a", "Öğretmen", "ÖĞRETMEN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c07b258-ce3e-42c7-8db1-732c7538a174", "Kullanıcı", "KULLANICI" });

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
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "ba7e2302-7bee-45c6-a389-e74919958d50", "AQAAAAIAAYagAAAAEK6nMZceZ69qtafzH3sJ1nKms81To5FF02YYuhfQA0uOx4TW22aJlvicEvrcTBmhbQ==", "3808a1dc-df8e-4751-a058-c639552126fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "bfba86b8-e032-48b0-9eb9-77e9010da302", "AQAAAAIAAYagAAAAEFSRA5BaLgFAh1I/TtxD5FyQYHhQ7+R9GWrnxd4pzMn9m0AFzgcy6pZJYsEFeF+BjA==", "98851b7d-743d-49c7-bbe9-40665687fa3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "c2d8b032-1300-4a9c-9f0b-6705ca847f3b", "AQAAAAIAAYagAAAAEMIm+Na0CZohtloKpuexuWBimogJ7V0RbdpO5BtMUBwPfI6Ds1f0tgTXd95KM43ARQ==", "1a98ff7b-42d3-4a02-93f3-6e288378aedc" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 12, 886, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "753e9a08-5f5b-4178-8da2-1c21668b2593", "Student", "STUDENT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "990d5470-0ef0-43a9-b107-6a5b42005e13", "Teacher", "TEACHER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95d106d9-ff25-4427-abcf-2213217c2ace", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "26c23a69-6a3e-405c-ba2a-629fc435c2ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec2b04aa-5a92-407d-9673-c054dac40a61", "AQAAAAIAAYagAAAAEFD23krncSpuBHHOTC/0CVx0p5cCkw49baizQn2uqyA3ZTe42Pr6prSzlBQyfg7nLw==", "d1d2bde3-e1c1-421d-83f6-da55c3ee8807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "debc0d19-e2da-462a-aa2a-38760568efb6", "AQAAAAIAAYagAAAAEG7V29t1dhC9/lfco5XxYymA7yzWQ8RZkJwRJn7iMYqbiZomKVqbg5MocUOWP4HfSA==", "543c93f4-4da1-4d83-b07e-6014b3b3e61e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96be7221-3863-444f-8f7e-0661c7af8d68", "AQAAAAIAAYagAAAAEN+F12O0e55p8NRVti9c291Cq/6dZQkoJ2uT+xp3iqi4TmOCTzFnFnepUm8cg3t4zw==", "8b4e0dbf-d83b-4695-86f0-412252e739ac" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.InsertData(
                table: "LessonDocuments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "DocumentPath", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[] { new Guid("5dc921f3-0a71-47a8-abcd-77f913a0525c"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(1749), null, "test", false, null, "Deneme" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonDocumentId", "LessonName", "LessonVideoId", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("45faf426-7593-47f8-b924-644284e88376"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3348), null, 3, false, "F205", 3, null, "Fizik", null, null, null },
                    { new Guid("99f26f35-8bd0-4bcb-8326-73ec522983c0"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3323), null, 1, false, "B100", 2, null, "Bilgisayar Sistemleri", null, null, null },
                    { new Guid("bda4a05f-778a-41f6-8dc0-1213e3074772"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3351), null, 4, false, "B101", 3, null, "Biyoloji", null, null, null },
                    { new Guid("f642e262-f9e4-454c-b32d-68170b3d29ef"), "Undefined", new DateTime(2024, 3, 6, 14, 53, 13, 187, DateTimeKind.Local).AddTicks(3339), null, 2, false, "M102", 5, null, "Matematik", null, null, null }
                });
        }
    }
}
