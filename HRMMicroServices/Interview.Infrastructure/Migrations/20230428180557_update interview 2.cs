using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview.Infrastructure.Migrations
{
    public partial class updateinterview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeLookupCode",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeLookupCode",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewTypeLookupCode",
                table: "Interviews");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeCode",
                table: "Interviews",
                column: "InterviewTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeCode",
                table: "Interviews",
                column: "InterviewTypeCode",
                principalTable: "InterviewTypes",
                principalColumn: "LookupCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeCode",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeCode",
                table: "Interviews");

            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeLookupCode",
                table: "Interviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeLookupCode",
                table: "Interviews",
                column: "InterviewTypeLookupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewTypes_InterviewTypeLookupCode",
                table: "Interviews",
                column: "InterviewTypeLookupCode",
                principalTable: "InterviewTypes",
                principalColumn: "LookupCode");
        }
    }
}
