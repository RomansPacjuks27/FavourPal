using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourPal.Domain.Migrations
{
    public partial class addidentitytokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RequestFromUser",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RequestToUser",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "DebtReturned",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DebtTaken",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Accepted",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RequestToUser",
                schema: "dbo",
                table: "Requests",
                newName: "SenderUserId");

            migrationBuilder.RenameColumn(
                name: "RequestFromUser",
                schema: "dbo",
                table: "Requests",
                newName: "RecipientUserId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "dbo",
                table: "Requests",
                newName: "AmountRequested");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestToUser",
                schema: "dbo",
                table: "Requests",
                newName: "IX_Requests_SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestFromUser",
                schema: "dbo",
                table: "Requests",
                newName: "IX_Requests_RecipientUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                schema: "dbo",
                table: "Requests",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "dbo",
                table: "Requests",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                schema: "dbo",
                table: "Requests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Owed = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Lent = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SenderUserId = table.Column<string>(nullable: true),
                    RecipientUserId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SendOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_AspNetUsers_RecipientUserId",
                        column: x => x.RecipientUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_AspNetUsers_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UserId",
                table: "Balances",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_RecipientUserId",
                schema: "dbo",
                table: "Transfers",
                column: "RecipientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SenderUserId",
                schema: "dbo",
                table: "Transfers",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RecipientUserId",
                schema: "dbo",
                table: "Requests",
                column: "RecipientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_SenderUserId",
                schema: "dbo",
                table: "Requests",
                column: "SenderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RecipientUserId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_SenderUserId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Transfers",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Message",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                schema: "dbo",
                table: "Requests",
                newName: "RequestToUser");

            migrationBuilder.RenameColumn(
                name: "RecipientUserId",
                schema: "dbo",
                table: "Requests",
                newName: "RequestFromUser");

            migrationBuilder.RenameColumn(
                name: "AmountRequested",
                schema: "dbo",
                table: "Requests",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_SenderUserId",
                schema: "dbo",
                table: "Requests",
                newName: "IX_Requests_RequestToUser");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RecipientUserId",
                schema: "dbo",
                table: "Requests",
                newName: "IX_Requests_RequestFromUser");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                schema: "dbo",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AspNetUsers",
                type: "decimal(10, 2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                schema: "dbo",
                table: "Requests",
                column: "RequestId");

            migrationBuilder.CreateTable(
                name: "DebtReturned",
                schema: "dbo",
                columns: table => new
                {
                    DebtReturnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    ReturnFromUser = table.Column<string>(nullable: true),
                    ReturnToUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtReturned", x => x.DebtReturnId);
                    table.ForeignKey(
                        name: "FK_DebtReturned_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "dbo",
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtReturned_AspNetUsers_ReturnFromUser",
                        column: x => x.ReturnFromUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebtReturned_AspNetUsers_ReturnToUser",
                        column: x => x.ReturnToUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebtTaken",
                schema: "dbo",
                columns: table => new
                {
                    DebtTakenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTaken", x => x.DebtTakenId);
                    table.ForeignKey(
                        name: "FK_DebtTaken_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "dbo",
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtReturned_RequestId",
                schema: "dbo",
                table: "DebtReturned",
                column: "RequestId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DebtTaken_RequestId",
                schema: "dbo",
                table: "DebtTaken",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RequestFromUser",
                schema: "dbo",
                table: "Requests",
                column: "RequestFromUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RequestToUser",
                schema: "dbo",
                table: "Requests",
                column: "RequestToUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
