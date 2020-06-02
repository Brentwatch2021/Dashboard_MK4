using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JTFA_Client_
{
    public partial class Dashboard_MK4ModelsV2_ModelsJTFA_Client_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JTFA_Clients",
                columns: table => new
                {
                    JTFA_CLIENT_ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Notifications_Permission_Levels_Allowed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTFA_Clients", x => x.JTFA_CLIENT_ID);
                });

            migrationBuilder.InsertData(
                table: "JTFA_Clients",
                columns: new[] { "JTFA_CLIENT_ID", "Email", "Name", "Notifications_Permission_Levels_Allowed", "PhoneNumber" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), "----------Daffyduckrules@WarnerBros.com ---------", "----------Daffy Duck------------", "Yes", "-----0000----" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JTFA_Clients");
        }
    }
}
