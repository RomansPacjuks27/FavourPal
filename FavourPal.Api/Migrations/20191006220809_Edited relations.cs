using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourPal.Api.Migrations
{
    public partial class Editedrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtReturned_AspNetUsers_FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtReturned_AspNetUsers_FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropIndex(
                name: "IX_DebtReturned_FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropIndex(
                name: "IX_DebtReturned_FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropColumn(
                name: "FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropColumn(
                name: "FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.AlterColumn<string>(
                name: "ReturnToUser",
                schema: "dbo",
                table: "DebtReturned",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned",
                column: "ReturnFromUser");

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_ReturnToUser",
                schema: "dbo",
                table: "DebtReturned",
                column: "ReturnToUser");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtReturned_AspNetUsers_ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned",
                column: "ReturnFromUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtReturned_AspNetUsers_ReturnToUser",
                schema: "dbo",
                table: "DebtReturned",
                column: "ReturnToUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtReturned_AspNetUsers_ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtReturned_AspNetUsers_ReturnToUser",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropIndex(
                name: "IX_DebtReturned_ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropIndex(
                name: "IX_DebtReturned_ReturnToUser",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.AlterColumn<string>(
                name: "ReturnToUser",
                schema: "dbo",
                table: "DebtReturned",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnFromUser",
                schema: "dbo",
                table: "DebtReturned",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned",
                column: "FK_ReturnFromId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned",
                column: "FK_ReturnToId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtReturned_AspNetUsers_FK_ReturnFromId",
                schema: "dbo",
                table: "DebtReturned",
                column: "FK_ReturnFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtReturned_AspNetUsers_FK_ReturnToId",
                schema: "dbo",
                table: "DebtReturned",
                column: "FK_ReturnToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
