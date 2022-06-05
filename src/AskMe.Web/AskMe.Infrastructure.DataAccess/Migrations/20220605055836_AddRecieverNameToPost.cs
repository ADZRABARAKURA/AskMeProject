using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskMe.Infrastructure.DataAccess.Migrations
{
    public partial class AddRecieverNameToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecieverId",
                table: "Posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "RecieverName",
                table: "Posts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RecieverName",
                table: "Posts");
        }
    }
}
