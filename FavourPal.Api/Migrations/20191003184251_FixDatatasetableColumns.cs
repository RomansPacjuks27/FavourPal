using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourPal.Api.Migrations
{
    public partial class FixDatatasetableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
