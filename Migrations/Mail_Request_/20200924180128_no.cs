using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.Mail_Request_
{
    public partial class no : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailRequests",
                columns: table => new
                {
                    Mail_Request_ID = table.Column<Guid>(nullable: false),
                    ToEmail = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    JobCardID = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRequests", x => x.Mail_Request_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailRequests");
        }
    }
}
