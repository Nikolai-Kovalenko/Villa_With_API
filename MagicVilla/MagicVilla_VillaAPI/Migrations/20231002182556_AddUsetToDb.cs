using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUsetToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocallUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocallUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 21, 25, 56, 767, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 21, 25, 56, 767, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 21, 25, 56, 767, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 21, 25, 56, 767, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 21, 25, 56, 767, DateTimeKind.Local).AddTicks(2064));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocallUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 13, 28, 687, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 13, 28, 687, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 13, 28, 687, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 13, 28, 687, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 13, 28, 687, DateTimeKind.Local).AddTicks(5219));
        }
    }
}
