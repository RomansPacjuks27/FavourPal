using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedTableDebeReturned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                schema: "dbo",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                schema: "dbo",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DebtReturned",
                schema: "dbo",
                columns: table => new
                {
                    DebtReturnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnFromUser = table.Column<string>(nullable: true),
                    ReturnToUser = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtReturned", x => x.DebtReturnId);
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
                    RequestId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
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
                name: "IX_Requests_UsersId",
                schema: "dbo",
                table: "Requests",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UsersId1",
                schema: "dbo",
                table: "Requests",
                column: "UsersId1");

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
                name: "FK_Requests_AspNetUsers_UsersId",
                schema: "dbo",
                table: "Requests",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_UsersId1",
                schema: "dbo",
                table: "Requests",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_UsersId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_UsersId1",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "DebtReturned",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DebtTaken",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UsersId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UsersId1",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UsersId",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                schema: "dbo",
                table: "Requests");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    OperationType = table.Column<string>(type: "varchar(255)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "dbo",
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_RequestId",
                table: "Operations",
                column: "RequestId",
                unique: true);
        }
    }
}
