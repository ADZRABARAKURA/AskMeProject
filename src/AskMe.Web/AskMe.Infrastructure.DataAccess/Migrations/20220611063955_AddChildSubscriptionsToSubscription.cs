using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskMe.Infrastructure.DataAccess.Migrations
{
    public partial class AddChildSubscriptionsToSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Subscriptions_SubscriptionId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_SubscriptionId",
                table: "Publications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
