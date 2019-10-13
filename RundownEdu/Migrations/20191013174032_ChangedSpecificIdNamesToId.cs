using Microsoft.EntityFrameworkCore.Migrations;

namespace RundownEdu.Migrations
{
    public partial class ChangedSpecificIdNamesToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Shows",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RundownId",
                table: "Rundowns",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Rundowns",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shows",
                newName: "ShowId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rundowns",
                newName: "RundownId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Rundowns",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
