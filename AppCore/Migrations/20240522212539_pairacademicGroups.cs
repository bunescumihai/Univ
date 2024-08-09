using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class pairacademicGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairAcademicGroup_AcademicGroups_AcademicGroupId",
                table: "PairAcademicGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PairAcademicGroup_Pairs_PairId",
                table: "PairAcademicGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PairAcademicGroup",
                table: "PairAcademicGroup");

            migrationBuilder.RenameTable(
                name: "PairAcademicGroup",
                newName: "PairAcademicGroups");

            migrationBuilder.RenameIndex(
                name: "IX_PairAcademicGroup_AcademicGroupId",
                table: "PairAcademicGroups",
                newName: "IX_PairAcademicGroups_AcademicGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PairAcademicGroups",
                table: "PairAcademicGroups",
                columns: new[] { "PairId", "AcademicGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PairAcademicGroups_AcademicGroups_AcademicGroupId",
                table: "PairAcademicGroups",
                column: "AcademicGroupId",
                principalTable: "AcademicGroups",
                principalColumn: "AcademicGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PairAcademicGroups_Pairs_PairId",
                table: "PairAcademicGroups",
                column: "PairId",
                principalTable: "Pairs",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairAcademicGroups_AcademicGroups_AcademicGroupId",
                table: "PairAcademicGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PairAcademicGroups_Pairs_PairId",
                table: "PairAcademicGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PairAcademicGroups",
                table: "PairAcademicGroups");

            migrationBuilder.RenameTable(
                name: "PairAcademicGroups",
                newName: "PairAcademicGroup");

            migrationBuilder.RenameIndex(
                name: "IX_PairAcademicGroups_AcademicGroupId",
                table: "PairAcademicGroup",
                newName: "IX_PairAcademicGroup_AcademicGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PairAcademicGroup",
                table: "PairAcademicGroup",
                columns: new[] { "PairId", "AcademicGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PairAcademicGroup_AcademicGroups_AcademicGroupId",
                table: "PairAcademicGroup",
                column: "AcademicGroupId",
                principalTable: "AcademicGroups",
                principalColumn: "AcademicGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PairAcademicGroup_Pairs_PairId",
                table: "PairAcademicGroup",
                column: "PairId",
                principalTable: "Pairs",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
