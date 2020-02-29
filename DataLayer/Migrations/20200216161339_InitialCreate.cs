using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalWord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalWord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslateWord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    OriginalWordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateWord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateWord_OriginalWord_OriginalWordId",
                        column: x => x.OriginalWordId,
                        principalTable: "OriginalWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslateWord_OriginalWordId",
                table: "TranslateWord",
                column: "OriginalWordId");
            
            
            migrationBuilder.CreateIndex(
                name: "IX_TranslateWord_Text",
                table: "TranslateWord",
                column: "Text");
            
            migrationBuilder.CreateIndex(
                name: "IX_OriginalWord_Text",
                table: "OriginalWord",
                column: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslateWord");

            migrationBuilder.DropTable(
                name: "OriginalWord");
        }
    }
}
