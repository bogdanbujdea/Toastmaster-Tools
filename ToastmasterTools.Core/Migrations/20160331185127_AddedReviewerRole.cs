using Microsoft.Data.Entity.Migrations;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.Core.Migrations
{
    public partial class AddedReviewerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reviewer",
                table: "Speech",
                nullable: false,
                defaultValue: ReviewerRole.Timer);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Counter_Speech_SpeechId", table: "Counter");
            migrationBuilder.DropForeignKey(name: "FK_Speech_Speaker_SpeakerId", table: "Speech");
            migrationBuilder.DropColumn(name: "Reviewer", table: "Speech");
            migrationBuilder.AddForeignKey(
                name: "FK_Counter_Speech_SpeechId",
                table: "Counter",
                column: "SpeechId",
                principalTable: "Speech",
                principalColumn: "SpeechId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Speech_Speaker_SpeakerId",
                table: "Speech",
                column: "SpeakerId",
                principalTable: "Speaker",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
