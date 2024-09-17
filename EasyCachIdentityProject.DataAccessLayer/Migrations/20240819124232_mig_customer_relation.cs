using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCachIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_customer_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "CustomerAccountsProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "CustomerAccountsProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsProcesses_ReceiverID",
                table: "CustomerAccountsProcesses",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsProcesses_SenderID",
                table: "CustomerAccountsProcesses",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsProcesses",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountsProcesses",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsProcesses_ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsProcesses_SenderID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "CustomerAccountsProcesses");
        }
    }
}
