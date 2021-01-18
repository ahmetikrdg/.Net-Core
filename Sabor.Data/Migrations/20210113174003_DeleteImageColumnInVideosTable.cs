using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabor.Data.Migrations
{
    public partial class DeleteImageColumnInVideosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Videos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
