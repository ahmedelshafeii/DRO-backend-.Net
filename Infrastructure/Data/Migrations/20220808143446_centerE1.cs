using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class centerE1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "WeekDays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_ClinicId",
                table: "WeekDays",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDays_Clinics_ClinicId",
                table: "WeekDays",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDays_Clinics_ClinicId",
                table: "WeekDays");

            migrationBuilder.DropIndex(
                name: "IX_WeekDays_ClinicId",
                table: "WeekDays");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "WeekDays");
        }
    }
}
