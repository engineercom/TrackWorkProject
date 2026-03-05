using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackWorkProject.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class mig_personelDuties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelDuty_Duties_DutyId",
                table: "PersonelDuty");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelDuty_Personels_PersonelId",
                table: "PersonelDuty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelDuty",
                table: "PersonelDuty");

            migrationBuilder.RenameTable(
                name: "PersonelDuty",
                newName: "PersonelDuties");

            migrationBuilder.RenameIndex(
                name: "IX_PersonelDuty_DutyId",
                table: "PersonelDuties",
                newName: "IX_PersonelDuties_DutyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelDuties",
                table: "PersonelDuties",
                columns: new[] { "PersonelId", "DutyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelDuties_Duties_DutyId",
                table: "PersonelDuties",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelDuties_Personels_PersonelId",
                table: "PersonelDuties",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelDuties_Duties_DutyId",
                table: "PersonelDuties");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelDuties_Personels_PersonelId",
                table: "PersonelDuties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelDuties",
                table: "PersonelDuties");

            migrationBuilder.RenameTable(
                name: "PersonelDuties",
                newName: "PersonelDuty");

            migrationBuilder.RenameIndex(
                name: "IX_PersonelDuties_DutyId",
                table: "PersonelDuty",
                newName: "IX_PersonelDuty_DutyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelDuty",
                table: "PersonelDuty",
                columns: new[] { "PersonelId", "DutyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelDuty_Duties_DutyId",
                table: "PersonelDuty",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelDuty_Personels_PersonelId",
                table: "PersonelDuty",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
