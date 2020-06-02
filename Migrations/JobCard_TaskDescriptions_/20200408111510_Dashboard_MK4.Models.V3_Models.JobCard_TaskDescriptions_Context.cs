using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class Dashboard_MK4ModelsV3_ModelsJobCard_TaskDescriptions_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCards",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(nullable: false),
                    JobCardName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCards", x => x.JobCardID);
                });

            migrationBuilder.CreateTable(
                name: "TaskDescriptions",
                columns: table => new
                {
                    Task_Description_ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LabourCost = table.Column<string>(nullable: true),
                    PartsPrice = table.Column<string>(nullable: true),
                    TotalTaskCost = table.Column<string>(nullable: true),
                    JobCardID = table.Column<Guid>(nullable: false),
                    JobCardV3JobCardID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDescriptions", x => x.Task_Description_ID);
                    table.ForeignKey(
                        name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                        column: x => x.JobCardV3JobCardID,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "JobCards",
                columns: new[] { "JobCardID", "JobCardName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), "Clutch Replacement" });

            migrationBuilder.InsertData(
                table: "TaskDescriptions",
                columns: new[] { "Task_Description_ID", "Description", "JobCardID", "JobCardV3JobCardID", "LabourCost", "PartsPrice", "TotalTaskCost" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), "Remove and fit clutch", new Guid("00000000-0000-0000-0000-000000000012"), null, "1500", "2000", "3500" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDescriptions");

            migrationBuilder.DropTable(
                name: "JobCards");
        }
    }
}
