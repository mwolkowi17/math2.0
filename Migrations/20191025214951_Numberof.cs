using Microsoft.EntityFrameworkCore.Migrations;

namespace Przyklady_pojedyncze.Migrations
{
    public partial class Numberof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numberofex",
                table: "Wyniki",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numberofex",
                table: "Wyniki");
        }
    }
}
