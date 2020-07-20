using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JTFA_Invoice_
{
    public partial class Add_Email_Recipeints_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_Recipients",
                table: "JTFA_Invoice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Recipients",
                table: "JTFA_Invoice");
        }
    }
}
