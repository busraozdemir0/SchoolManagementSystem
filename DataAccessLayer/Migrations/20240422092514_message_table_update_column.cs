using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class messagetableupdatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("1bb1842f-d0be-4bdc-bede-7d9f5678af2e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("361182e6-e970-4ab8-b192-bb90ce39f1cf"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ae2fc38e-88fc-43fe-bd4f-fe202a28464e"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e68f0fce-4313-4d18-ac11-1fa17a99ca42"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3288f782-f8bb-49c4-b631-b73b30ba3cb2"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("59d556c3-cef0-4a9d-8f8e-504220c75404"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b4dced7f-708b-4a08-955e-3b793c08d94b"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("ea6ccbaf-3081-4737-9dc1-984a62d89f90"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("f3932317-dba3-45c9-8f9e-b6a9603f14e8"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("fa7e12ae-79e8-49d3-aa32-f230a4541b71"));

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Messages",
                newName: "IsDeleted");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 56, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 56, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "ebc4335d-372d-40d1-954c-65674e5ffe8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "872cd129-d935-4f31-bdc9-e5ef974cd38f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "5fcb8ce9-9b89-41ba-8a25-f26f74b76c69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "5c669c5f-0e86-4101-bd43-108a9d122fc6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51396677-cc7e-4911-837c-8a51945fa498", "AQAAAAIAAYagAAAAELvPFeOGSwCfR/lpNyIyspYsrovVurGcmauO80C9RGXBzcp70bgSNQmVokS/sCzw8w==", "68a3d6a3-789b-4d26-bf72-ea4b2da8c532" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "432671db-8b38-4fac-af6f-22fcba411674", "AQAAAAIAAYagAAAAEBtSyE2Tf+X1Jsyr8pFRiUFXsNtFF4qekNdvGphTkrnVzks4LgxTBvRpNNFx52F/vA==", "a7b3cdb8-91fe-4a94-a662-5c9d07f882db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41d7ce62-f6f9-4bfb-89d2-3d7adfa16446", "AQAAAAIAAYagAAAAEMsjH2XpvLP1bD4EnD10ioPh71aalWn6ptwKGf3NM5pB3wcCFUjt54nFSU+oHdUoTA==", "8a3706c9-04ff-43a5-9431-07bf34246090" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("3d0883bb-a9fb-4d21-926e-a89a3c097bd6"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9141), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("51845db5-1432-4094-88d8-f341789f9b23"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9095), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("6ff168db-f4f5-4e17-91eb-4c54182ff6ef"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9134), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("c76b8bfc-579b-4fd6-b824-61a41a964087"), "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 350, DateTimeKind.Local).AddTicks(9138), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0b01b7eb-d82b-4d51-9d35-3f0b2e250424"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5517), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" },
                    { new Guid("8695636e-9bad-4a19-91df-aa424222f6f0"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5476), null, null, false, null, "Deneme" },
                    { new Guid("b45d0bcb-1ece-4fa9-974d-c53bd8953313"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5502), null, null, false, null, "Where can I get some?" },
                    { new Guid("c307acf5-40e4-4511-b70b-a030904dc095"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5492), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("d42680f0-6fa9-4e3b-a0ee-50f75cec81fc"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5525), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("d78829cd-a8b1-4349-bca2-b2b07593423c"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 22, 12, 25, 13, 351, DateTimeKind.Local).AddTicks(5500), null, null, false, null, "Lorem İpsum" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("3d0883bb-a9fb-4d21-926e-a89a3c097bd6"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("51845db5-1432-4094-88d8-f341789f9b23"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("6ff168db-f4f5-4e17-91eb-4c54182ff6ef"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c76b8bfc-579b-4fd6-b824-61a41a964087"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("0b01b7eb-d82b-4d51-9d35-3f0b2e250424"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8695636e-9bad-4a19-91df-aa424222f6f0"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b45d0bcb-1ece-4fa9-974d-c53bd8953313"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c307acf5-40e4-4511-b70b-a030904dc095"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d42680f0-6fa9-4e3b-a0ee-50f75cec81fc"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("d78829cd-a8b1-4349-bca2-b2b07593423c"));

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Messages",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 46, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 46, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2157a98d-0223-4ae6-afb9-5f586e9ba4ae"),
                column: "ConcurrencyStamp",
                value: "db425899-0bf9-4db3-80df-781be5bfb8a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23420044-c9ae-462e-8317-88db8c734de1"),
                column: "ConcurrencyStamp",
                value: "8be10ad4-d5ca-4e74-95d1-05cf603c9b9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8db4507c-ee16-4f5f-82a6-d187a2acb21d"),
                column: "ConcurrencyStamp",
                value: "da9661cd-4282-4c2d-b2c2-968361aa8cdb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c54083a8-1ff1-43d0-9b51-c2fea5b3e60d"),
                column: "ConcurrencyStamp",
                value: "559b056f-9edf-4a13-bb92-a4011e025669");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("97b90210-a67f-426d-be2c-8adcab3100fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "837e5e70-d75a-4065-803d-46c45363d091", "AQAAAAIAAYagAAAAENfwT5e5M/dZ4/jC7j6M+qyvN1u0RGJbaihNWIebag06UuZHcRVYv0wYIzQPVzcV7A==", "5c595435-f4f2-4433-8932-192827567d48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a61f597b-2c8d-4cb4-80a6-6822178322a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff00a1f8-0be6-4dbe-92c0-3e77efe6ee45", "AQAAAAIAAYagAAAAEB0IiooeRBKhnwAUTpSb9uMjYK92wakZWye/U64thKRLVIx87p4Xw6DLlMbBZN4Y/Q==", "ed0de48e-cdb5-4c12-89b1-33e1604848c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9949a78-7413-484e-a62a-eb0fb01b7f76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "277b813c-d5e4-4299-b2ea-8dc0539c3ef2", "AQAAAAIAAYagAAAAEJlnKRH4d7LYECQ/SpH7pNaka3KGuqjyZ6YB/U8UBIhEKnuXAIJY66eTMcp/Mgp4+A==", "accd793f-c484-4b8f-8892-6048af51e27c" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "GradeId", "IsDeleted", "LessonCode", "LessonCredit", "LessonName", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1bb1842f-d0be-4bdc-bede-7d9f5678af2e"), "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(4786), null, 1, false, "B100", 2, "Bilgisayar Sistemleri", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("361182e6-e970-4ab8-b192-bb90ce39f1cf"), "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(4829), null, 2, false, "M102", 5, "Matematik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("ae2fc38e-88fc-43fe-bd4f-fe202a28464e"), "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(4833), null, 3, false, "F205", 3, "Fizik", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") },
                    { new Guid("e68f0fce-4313-4d18-ac11-1fa17a99ca42"), "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 298, DateTimeKind.Local).AddTicks(4836), null, 4, false, "B101", 3, "Biyoloji", null, new Guid("97b90210-a67f-426d-be2c-8adcab3100fb") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("3288f782-f8bb-49c4-b631-b73b30ba3cb2"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5060), null, null, false, null, "Gelecekte Yapay Zeka" },
                    { new Guid("59d556c3-cef0-4a9d-8f8e-504220c75404"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5062), null, null, false, null, "Lorem İpsum" },
                    { new Guid("b4dced7f-708b-4a08-955e-3b793c08d94b"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5040), null, null, false, null, "Deneme" },
                    { new Guid("ea6ccbaf-3081-4737-9dc1-984a62d89f90"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5064), null, null, false, null, "Where can I get some?" },
                    { new Guid("f3932317-dba3-45c9-8f9e-b6a9603f14e8"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5123), null, null, false, null, "Bir Ödül Daha Kazandık" },
                    { new Guid("fa7e12ae-79e8-49d3-aa32-f230a4541b71"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary", "Undefined", new DateTime(2024, 4, 20, 14, 36, 40, 299, DateTimeKind.Local).AddTicks(5121), null, null, false, null, "Okulumuz Türkiye En'leri Arasında" }
                });
        }
    }
}
