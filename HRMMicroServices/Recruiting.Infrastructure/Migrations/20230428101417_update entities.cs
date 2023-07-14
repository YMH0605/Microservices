using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    public partial class updateentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubmissionStatuses",
                type: "nvarchar(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobRequirements",
                type: "nvarchar(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobRequirements",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "ClosedReason",
                table: "JobRequirements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubmissionStatuses",
                type: "nvarchar(512)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobRequirements",
                type: "nvarchar(512)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobRequirements",
                type: "varchar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClosedReason",
                table: "JobRequirements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
