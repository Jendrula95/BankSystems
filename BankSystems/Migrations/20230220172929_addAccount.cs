using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class addAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Account_AccountID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Cards",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_AccountID",
                table: "Cards",
                newName: "IX_Cards_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Account_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Account_AccountId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Cards",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_AccountId",
                table: "Cards",
                newName: "IX_Cards_AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Account_AccountID",
                table: "Cards",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
