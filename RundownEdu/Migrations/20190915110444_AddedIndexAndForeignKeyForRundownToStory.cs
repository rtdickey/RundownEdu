using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RundownEdu.Migrations
{
    public partial class AddedIndexAndForeignKeyForRundownToStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                });

            migrationBuilder.CreateTable(
                name: "Rundowns",
                columns: table => new
                {
                    RundownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    ShowId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rundowns", x => x.RundownId);
                    table.ForeignKey(
                        name: "FK_Rundowns_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    StoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    RundownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_Stories_Rundowns_RundownId",
                        column: x => x.RundownId,
                        principalTable: "Rundowns",
                        principalColumn: "RundownId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    SegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Reader = table.Column<string>(nullable: true),
                    EstimatedReadTime = table.Column<string>(nullable: true),
                    ActualReadTime = table.Column<string>(nullable: true),
                    StoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.SegmentId);
                    table.ForeignKey(
                        name: "FK_Segments_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rundowns_ShowId",
                table: "Rundowns",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_StoryId",
                table: "Segments",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_RundownId",
                table: "Stories",
                column: "RundownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Rundowns");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
