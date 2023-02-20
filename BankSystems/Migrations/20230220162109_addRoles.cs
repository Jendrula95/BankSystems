using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Transaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountID",
                table: "Transaction",
                newName: "IX_Transaction_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transaction",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                newName: "IX_Transaction_AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountID",
                table: "Transaction",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
