using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DI.Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class smallfix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dob_Date",
                table: "Users",
                newName: "DoB_Date");

            migrationBuilder.RenameColumn(
                name: "Dob_Age",
                table: "Users",
                newName: "DoB_Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoB_Date",
                table: "Users",
                newName: "Dob_Date");

            migrationBuilder.RenameColumn(
                name: "DoB_Age",
                table: "Users",
                newName: "Dob_Age");
        }
    }
}
