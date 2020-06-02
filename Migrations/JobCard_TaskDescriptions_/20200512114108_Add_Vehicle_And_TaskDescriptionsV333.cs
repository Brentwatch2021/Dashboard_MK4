using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class Add_Vehicle_And_TaskDescriptionsV333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Client_Display_ID_ClientDisplayID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCards",
                table: "JobCards");

            migrationBuilder.RenameTable(
                name: "JobCards",
                newName: "JobCardsV3");

            migrationBuilder.RenameIndex(
                name: "IX_JobCards_Vehicle_ID",
                table: "JobCardsV3",
                newName: "IX_JobCardsV3_Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCards_VehicleV3Vehicle_ID",
                table: "JobCardsV3",
                newName: "IX_JobCardsV3_VehicleV3Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCards_VehicleDisplayID",
                table: "JobCardsV3",
                newName: "IX_JobCardsV3_VehicleDisplayID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCards_ClientDisplayID",
                table: "JobCardsV3",
                newName: "IX_JobCardsV3_ClientDisplayID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCardsV3",
                table: "JobCardsV3",
                column: "JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardsV3_Client_Display_ID_ClientDisplayID",
                table: "JobCardsV3",
                column: "ClientDisplayID",
                principalTable: "Client_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardsV3_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCardsV3",
                column: "VehicleDisplayID",
                principalTable: "Vehicle_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardsV3_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCardsV3",
                column: "VehicleV3Vehicle_ID",
                principalTable: "Vehicles_V3",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCardsV3_Vehicles_Vehicle_ID",
                table: "JobCardsV3",
                column: "Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDescriptions_JobCardsV3_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID",
                principalTable: "JobCardsV3",
                principalColumn: "JobCardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCardsV3_Client_Display_ID_ClientDisplayID",
                table: "JobCardsV3");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardsV3_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCardsV3");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardsV3_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCardsV3");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCardsV3_Vehicles_Vehicle_ID",
                table: "JobCardsV3");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDescriptions_JobCardsV3_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCardsV3",
                table: "JobCardsV3");

            migrationBuilder.RenameTable(
                name: "JobCardsV3",
                newName: "JobCards");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardsV3_Vehicle_ID",
                table: "JobCards",
                newName: "IX_JobCards_Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardsV3_VehicleV3Vehicle_ID",
                table: "JobCards",
                newName: "IX_JobCards_VehicleV3Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardsV3_VehicleDisplayID",
                table: "JobCards",
                newName: "IX_JobCards_VehicleDisplayID");

            migrationBuilder.RenameIndex(
                name: "IX_JobCardsV3_ClientDisplayID",
                table: "JobCards",
                newName: "IX_JobCards_ClientDisplayID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCards",
                table: "JobCards",
                column: "JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Client_Display_ID_ClientDisplayID",
                table: "JobCards",
                column: "ClientDisplayID",
                principalTable: "Client_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCards",
                column: "VehicleDisplayID",
                principalTable: "Vehicle_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCards",
                column: "VehicleV3Vehicle_ID",
                principalTable: "Vehicles_V3",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_Vehicle_ID",
                table: "JobCards",
                column: "Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID",
                principalTable: "JobCards",
                principalColumn: "JobCardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
