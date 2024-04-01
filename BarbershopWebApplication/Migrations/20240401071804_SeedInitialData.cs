using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopWebApplication.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WillAttend",
                table: "Recordings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WillAttend",
                table: "Recordings",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
