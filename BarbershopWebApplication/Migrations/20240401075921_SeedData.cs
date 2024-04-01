using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopWebApplication.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "BarberId", "Name" },
                values: new object[,]
                {
                    { 1, "Иван" },
                    { 2, "Пётр" },
                    { 3, "Антон" },
                    { 4, "Сергей" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 800m, "Стрижка машинкой" },
                    { 2, 1500m, "Детская стрижка" },
                    { 3, 1600m, "Стрижка машинкой Fade" },
                    { 4, 2100m, "Мужская стрижка" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "BarberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "BarberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "BarberId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "BarberId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4);
        }
    }
}
