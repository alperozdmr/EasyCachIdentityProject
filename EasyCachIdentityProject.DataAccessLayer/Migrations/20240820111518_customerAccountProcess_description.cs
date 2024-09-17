using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCachIdentityProject.DataAccessLayer.Migrations
{
    public partial class customerAccountProcess_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerAccountsProcesses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerAccountsProcesses");
        }
    }
}
