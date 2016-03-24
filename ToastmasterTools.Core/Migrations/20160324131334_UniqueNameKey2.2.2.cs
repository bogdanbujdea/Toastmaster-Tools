using Microsoft.Data.Entity.Migrations;

namespace ToastmasterTools.Core.Migrations
{
    public partial class UniqueNameKey222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SpeechType_Name",
                table: "SpeechType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_SpeechType_Name", table: "SpeechType");
        }
    }
}
