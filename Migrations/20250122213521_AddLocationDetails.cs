using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_LocationID",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Country");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_LocationID",
                table: "Rentals",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_LocationID",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Locations",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Rentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_LocationID",
                table: "Rentals",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID");
        }
    }
}
