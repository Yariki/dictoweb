using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DictoData.Migrations
{
    public partial class AddObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Created = table.Column<DateTime>( nullable: false),
                    Description = table.Column<string>( nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>( nullable: false)
                        .Annotation("Autoincrement", true),
                    CountNew = table.Column<int>( nullable: false),
                    Created = table.Column<DateTime>( nullable: false),
                    LastUsedSM2 = table.Column<DateTime>( nullable: false),
                    Minute = table.Column<int>( nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transcriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Created = table.Column<DateTime>( nullable: false),
                    Original = table.Column<string>( nullable: true),
                    Phonetic = table.Column<string>( nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    DeckId = table.Column<int>( nullable: false),
                    Level = table.Column<int>( nullable: false),
                    Phonetic = table.Column<string>(nullable: true),
                    Text = table.Column<string>( nullable: true),
                    UserId = table.Column<int>( nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SuperMemories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Created = table.Column<DateTime>( nullable: false),
                    EF = table.Column<double>(nullable: false),
                    LastRepetition = table.Column<DateTime>( nullable: false),
                    NextRepetition = table.Column<DateTime>( nullable: false),
                    Repetition = table.Column<int>( nullable: false),
                    RepetitionInterval = table.Column<int>( nullable: false),
                    WordId = table.Column<int>( nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperMemories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperMemories_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Created = table.Column<DateTime>( nullable: false),
                    Text = table.Column<string>( nullable: true),
                    WordId = table.Column<int>( nullable: false),
                    WordType = table.Column<int>( nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperMemories_WordId",
                table: "SuperMemories",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translates_WordId",
                table: "Translates",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_DeckId",
                table: "Words",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_UserId",
                table: "Words",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SuperMemories");

            migrationBuilder.DropTable(
                name: "Transcriptions");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
