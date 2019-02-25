using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_cny.API.Migrations
{
    public partial class mi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_Identification_IdentificationId",
                table: "EmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_Patients_PatientId",
                table: "EmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_Relationship_RelationshipId",
                table: "EmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Identification_IdentificationId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identification",
                table: "Identification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmergencyContact",
                table: "EmergencyContact");

            migrationBuilder.RenameTable(
                name: "Relationship",
                newName: "Relationships");

            migrationBuilder.RenameTable(
                name: "Identification",
                newName: "Identifications");

            migrationBuilder.RenameTable(
                name: "EmergencyContact",
                newName: "EmergencyContacts");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContact_RelationshipId",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContact_PatientId",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContact_IdentificationId",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_IdentificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships",
                column: "RelationshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identifications",
                table: "Identifications",
                column: "IdentificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts",
                column: "EmergencyContactId");

            migrationBuilder.CreateTable(
                name: "CurrentMRNs",
                columns: table => new
                {
                    RunningId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunningNum = table.Column<int>(nullable: false),
                    Prefix = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMRNs", x => x.RunningId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Identifications_IdentificationId",
                table: "EmergencyContacts",
                column: "IdentificationId",
                principalTable: "Identifications",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Patients_PatientId",
                table: "EmergencyContacts",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Relationships_RelationshipId",
                table: "EmergencyContacts",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients",
                column: "IdentificationId",
                principalTable: "Identifications",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Identifications_IdentificationId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Patients_PatientId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Relationships_RelationshipId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Identifications_IdentificationId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "CurrentMRNs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identifications",
                table: "Identifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts");

            migrationBuilder.RenameTable(
                name: "Relationships",
                newName: "Relationship");

            migrationBuilder.RenameTable(
                name: "Identifications",
                newName: "Identification");

            migrationBuilder.RenameTable(
                name: "EmergencyContacts",
                newName: "EmergencyContact");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_RelationshipId",
                table: "EmergencyContact",
                newName: "IX_EmergencyContact_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_PatientId",
                table: "EmergencyContact",
                newName: "IX_EmergencyContact_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_IdentificationId",
                table: "EmergencyContact",
                newName: "IX_EmergencyContact_IdentificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship",
                column: "RelationshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identification",
                table: "Identification",
                column: "IdentificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmergencyContact",
                table: "EmergencyContact",
                column: "EmergencyContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_Identification_IdentificationId",
                table: "EmergencyContact",
                column: "IdentificationId",
                principalTable: "Identification",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_Patients_PatientId",
                table: "EmergencyContact",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_Relationship_RelationshipId",
                table: "EmergencyContact",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Identification_IdentificationId",
                table: "Patients",
                column: "IdentificationId",
                principalTable: "Identification",
                principalColumn: "IdentificationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
