using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_cny.API.Migrations
{
    public partial class futhermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ICNo",
                table: "Patients",
                newName: "IdentificationId");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNo",
                table: "Patients",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MRN",
                table: "Patients",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Patients",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Identification",
                columns: table => new
                {
                    IdentificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentificationName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identification", x => x.IdentificationId);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelationshipName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.RelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    EmergencyContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactNo = table.Column<string>(maxLength: 20, nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
                    IdentificationNo = table.Column<string>(maxLength: 20, nullable: true),
                    IdentificationId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.EmergencyContactId);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Identification_IdentificationId",
                        column: x => x.IdentificationId,
                        principalTable: "Identification",
                        principalColumn: "IdentificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationship",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentificationId",
                table: "Patients",
                column: "IdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_IdentificationId",
                table: "EmergencyContact",
                column: "IdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContact",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_RelationshipId",
                table: "EmergencyContact",
                column: "RelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Identification_IdentificationId",
                table: "Patients",
                column: "IdentificationId",
                principalTable: "Identification",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Identification_IdentificationId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Identification");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropIndex(
                name: "IX_Patients_IdentificationId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdentificationNo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MRN",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "IdentificationId",
                table: "Patients",
                newName: "ICNo");
        }
    }
}
