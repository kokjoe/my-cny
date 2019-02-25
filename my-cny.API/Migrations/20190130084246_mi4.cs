using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_cny.API.Migrations
{
    public partial class mi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients",
                column: "IdentificationId",
                principalTable: "Identifications",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients",
                column: "IdentificationId",
                principalTable: "Identifications",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
