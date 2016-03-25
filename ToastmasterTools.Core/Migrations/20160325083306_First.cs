using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToastmasterTools.Core.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Club = table.Column<string>(nullable: true),
                    CurrentLesson = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsMember = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpeechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });
            migrationBuilder.CreateTable(
                name: "SpeechType",
                columns: table => new
                {
                    SpeechTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechType", x => x.SpeechTypeId);
                });
            migrationBuilder.CreateTable(
                name: "Speech",
                columns: table => new
                {
                    SpeechId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsCustom = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SpeakerId = table.Column<int>(nullable: false),
                    SpeechTimeInSeconds = table.Column<double>(nullable: false),
                    SpeechTypeSpeechTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speech", x => x.SpeechId);
                    table.ForeignKey(
                        name: "FK_Speech_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Speech_SpeechType_SpeechTypeSpeechTypeId",
                        column: x => x.SpeechTypeSpeechTypeId,
                        principalTable: "SpeechType",
                        principalColumn: "SpeechTypeId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Counter",
                columns: table => new
                {
                    CounterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpeechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counter", x => x.CounterId);
                    table.ForeignKey(
                        name: "FK_Counter_Speech_SpeechId",
                        column: x => x.SpeechId,
                        principalTable: "Speech",
                        principalColumn: "SpeechId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Counter");
            migrationBuilder.DropTable("Speech");
            migrationBuilder.DropTable("Speaker");
            migrationBuilder.DropTable("SpeechType");
        }
    }
}
