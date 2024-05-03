using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahaMedia.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_colunm_Mp3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Mp3Data",
                table: "Songs",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mp3Data",
                table: "Songs");
        }
    }
}
