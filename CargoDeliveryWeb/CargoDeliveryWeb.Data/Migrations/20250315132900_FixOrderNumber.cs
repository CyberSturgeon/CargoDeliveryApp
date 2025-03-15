using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoDeliveryWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<BigInteger>(
                name: "OrderNumber",
                table: "Orders",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(BigInteger),
                oldType: "numeric",
                oldDefaultValueSql: "substr(uuid_generate_v4()::text, 1, 8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<BigInteger>(
                name: "OrderNumber",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValueSql: "substr(uuid_generate_v4()::text, 1, 8)",
                oldClrType: typeof(BigInteger),
                oldType: "numeric");
        }
    }
}
