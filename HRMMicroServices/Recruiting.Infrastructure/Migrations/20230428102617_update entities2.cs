using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    public partial class updateentities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_SubmissionStatuses_SubmissionStatusLookupCode",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_SubmissionStatusLookupCode",
                table: "Submission");

            migrationBuilder.DropColumn(
                name: "SubmissionStatusLookupCode",
                table: "Submission");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionStatusCode",
                table: "Submission",
                column: "SubmissionStatusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_SubmissionStatuses_SubmissionStatusCode",
                table: "Submission",
                column: "SubmissionStatusCode",
                principalTable: "SubmissionStatuses",
                principalColumn: "LookupCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_SubmissionStatuses_SubmissionStatusCode",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_SubmissionStatusCode",
                table: "Submission");

            migrationBuilder.AddColumn<int>(
                name: "SubmissionStatusLookupCode",
                table: "Submission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionStatusLookupCode",
                table: "Submission",
                column: "SubmissionStatusLookupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_SubmissionStatuses_SubmissionStatusLookupCode",
                table: "Submission",
                column: "SubmissionStatusLookupCode",
                principalTable: "SubmissionStatuses",
                principalColumn: "LookupCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
