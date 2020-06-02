using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class Add_JTFA_ClientToJobcardV3Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JTFA_CLIENT_ID",
                table: "JobCardsV3",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCardsV3_JTFA_CLIENT_ID",
                table: "JobCardsV3",
                column: "JTFA_CLIENT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardsV3_JTFA_Clients_JTFA_CLIENT_ID",
                table: "JobCardsV3",
                column: "JTFA_CLIENT_ID",
                principalTable: "JTFA_Clients",
                principalColumn: "JTFA_CLIENT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardsV3_JTFA_Clients_JTFA_CLIENT_ID",
                table: "JobCardsV3");

            migrationBuilder.DropIndex(
                name: "IX_JobCardsV3_JTFA_CLIENT_ID",
                table: "JobCardsV3");

            migrationBuilder.DropColumn(
                name: "JTFA_CLIENT_ID",
                table: "JobCardsV3");
        }
    }
}
