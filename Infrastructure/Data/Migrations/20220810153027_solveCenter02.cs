using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.data.migrations
{
    public partial class solveCenter02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Doctors_DoctorId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_DoctorId",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Centers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Centers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Centers_DoctorId",
                table: "Centers",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Doctors_DoctorId",
                table: "Centers",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
