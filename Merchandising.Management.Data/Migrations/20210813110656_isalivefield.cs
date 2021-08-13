using Microsoft.EntityFrameworkCore.Migrations;

namespace Merchandising.Management.Data.Migrations
{
    public partial class isalivefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Categories");
        }
    }
}
