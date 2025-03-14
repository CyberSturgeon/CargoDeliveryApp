using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoDeliveryWeb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderCity = table.Column<string>(type: "text", nullable: false),
                    SenderAddress = table.Column<string>(type: "text", nullable: false),
                    ReceiverCity = table.Column<string>(type: "text", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
