using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedrelationbetweenRequestsandDebtReturned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                schema: "dbo",
                table: "DebtReturned",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_RequestId",
                schema: "dbo",
                table: "DebtReturned",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtReturned_Requests_RequestId",
                schema: "dbo",
                table: "DebtReturned",
                column: "RequestId",
                principalSchema: "dbo",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtReturned_Requests_RequestId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropIndex(
                name: "IX_DebtReturned_RequestId",
                schema: "dbo",
                table: "DebtReturned");

            migrationBuilder.DropColumn(
                name: "RequestId",
                schema: "dbo",
                table: "DebtReturned");
        }
    }
}
