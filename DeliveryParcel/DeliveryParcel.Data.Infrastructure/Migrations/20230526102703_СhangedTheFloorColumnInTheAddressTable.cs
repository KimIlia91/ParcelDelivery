using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryParcel.Data.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class СhangedTheFloorColumnInTheAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Flat",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Flat",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
