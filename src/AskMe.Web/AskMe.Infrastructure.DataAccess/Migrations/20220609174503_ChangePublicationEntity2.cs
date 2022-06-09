using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskMe.Infrastructure.DataAccess.Migrations
{
    public partial class ChangePublicationEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Profiles_UserProfileId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_UserProfileId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Publications");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Subscriptions_SubscriptionId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_SubscriptionId",
                table: "Publications");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Publications",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_UserProfileId",
                table: "Publications",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Profiles_UserProfileId",
                table: "Publications",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
