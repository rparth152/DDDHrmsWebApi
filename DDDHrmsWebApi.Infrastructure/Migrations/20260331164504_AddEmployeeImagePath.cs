using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDHrmsWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employee");
        }
    }
}
