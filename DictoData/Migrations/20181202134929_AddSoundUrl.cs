using Microsoft.EntityFrameworkCore.Migrations;

namespace DictoData.Migrations
{
    public partial class AddSoundUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sound",
                table: "Words",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sound",
                table: "Words");
        }
    }
}
