using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class RollbackToTaskDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDescripsDisplayIds");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardV3JobCardID",
                table: "TaskDescriptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID",
                principalTable: "JobCards",
                principalColumn: "JobCardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropColumn(
                name: "JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.CreateTable(
                name: "TaskDescripsDisplayIds",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardV3JobCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDescripsDisplayIds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskDescripsDisplayIds_JobCards_JobCardV3JobCardID",
                        column: x => x.JobCardV3JobCardID,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescripsDisplayIds_JobCardV3JobCardID",
                table: "TaskDescripsDisplayIds",
                column: "JobCardV3JobCardID");
        }
    }
}
