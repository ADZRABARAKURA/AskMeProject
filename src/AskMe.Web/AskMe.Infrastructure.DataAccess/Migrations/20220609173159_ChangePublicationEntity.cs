using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskMe.Infrastructure.DataAccess.Migrations
{
    public partial class ChangePublicationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Subscriptions_SubscriptionId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_SubscriptionId",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Publications",
                newName: "Header");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Publications",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "Publications",
                newName: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_SubscriptionId",
                table: "Publications",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Subscriptions_SubscriptionId",
                table: "Publications",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }
    }
}
