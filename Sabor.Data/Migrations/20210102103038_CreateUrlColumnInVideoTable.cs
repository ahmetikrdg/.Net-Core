using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabor.Data.Migrations
{
    public partial class CreateUrlColumnInVideoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Videos");
        }
    }
}
