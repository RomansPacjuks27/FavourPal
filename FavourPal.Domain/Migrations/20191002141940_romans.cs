﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourPal.Domain.Migrations
{
    public partial class romans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "dbo",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestFromUser = table.Column<int>(nullable: false),
                    RequestToUser = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FKRequestsUsers_RequestFromUser",
                        column: x => x.RequestFromUser,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FKRequestsUsers_RequestToUser",
                        column: x => x.RequestToUser,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IXRequests_RequestFromUser",
                schema: "dbo",
                table: "Requests",
                column: "RequestFromUser");

            migrationBuilder.CreateIndex(
                name: "IXRequests_RequestToUser",
                schema: "dbo",
                table: "Requests",
                column: "RequestToUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
