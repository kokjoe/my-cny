using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_cny.API.Migrations
{
    public partial class addsysfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Relationships",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Relationships",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAudit",
                table: "Relationships",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Relationships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Identifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "Identifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAudit",
                table: "Identifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Identifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmergencyContacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedDate",
                table: "EmergencyContacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAudit",
                table: "EmergencyContacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "EmergencyContacts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "IsAudit",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Identifications");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "Identifications");

            migrationBuilder.DropColumn(
                name: "IsAudit",
                table: "Identifications");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Identifications");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "EditedDate",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "IsAudit",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "EmergencyContacts");
        }
    }
}
