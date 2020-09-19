using Microsoft.EntityFrameworkCore.Migrations;

namespace RundownEdu.Migrations
{
    public partial class ChangedStorySpecifiedIdToJustId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "Stories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stories",
                newName: "StoryId");
        }
    }
}
