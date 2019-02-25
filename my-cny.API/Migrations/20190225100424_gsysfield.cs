using Microsoft.EntityFrameworkCore.Migrations;

namespace my_cny.API.Migrations
{
    public partial class gsysfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Relationships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patients");
        }
    }
}
