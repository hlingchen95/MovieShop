using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingTrailorFixError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailor_Movie_MovieId",
                table: "Trailor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailor",
                table: "Trailor");

            migrationBuilder.RenameTable(
                name: "Trailor",
                newName: "Trailer");

            migrationBuilder.RenameIndex(
                name: "IX_Trailor_MovieId",
                table: "Trailer",
                newName: "IX_Trailer_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer");

            migrationBuilder.RenameTable(
                name: "Trailer",
                newName: "Trailor");

            migrationBuilder.RenameIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailor",
                newName: "IX_Trailor_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailor",
                table: "Trailor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailor_Movie_MovieId",
                table: "Trailor",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
