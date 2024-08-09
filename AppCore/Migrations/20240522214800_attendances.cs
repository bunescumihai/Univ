using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class attendances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Pairs_PairId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Students_PersonId",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_PersonId_Date_PairId",
                table: "Attendances",
                newName: "IX_Attendances_PersonId_Date_PairId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_PairId",
                table: "Attendances",
                newName: "IX_Attendances_PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Pairs_PairId",
                table: "Attendances",
                column: "PairId",
                principalTable: "Pairs",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_PersonId",
                table: "Attendances",
                column: "PersonId",
                principalTable: "Students",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Pairs_PairId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_PersonId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_PersonId_Date_PairId",
                table: "Attendance",
                newName: "IX_Attendance_PersonId_Date_PairId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_PairId",
                table: "Attendance",
                newName: "IX_Attendance_PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Pairs_PairId",
                table: "Attendance",
                column: "PairId",
                principalTable: "Pairs",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Students_PersonId",
                table: "Attendance",
                column: "PersonId",
                principalTable: "Students",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
