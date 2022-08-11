using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.data.migrations
{
    public partial class workOnRelation02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Doctors_DoctorId1",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_DoctorId1",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Centers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId1",
                table: "Centers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Centers_DoctorId1",
                table: "Centers",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Doctors_DoctorId1",
                table: "Centers",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
