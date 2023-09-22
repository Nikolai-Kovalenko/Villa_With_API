using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableToFalse3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 167,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 9, 35, 139, DateTimeKind.Local).AddTicks(1394));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 167,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 22, 18, 7, 58, 716, DateTimeKind.Local).AddTicks(8476));
        }
    }
}
