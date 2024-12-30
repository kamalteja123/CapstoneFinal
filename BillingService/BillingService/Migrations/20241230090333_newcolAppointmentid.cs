using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingService.Migrations
{
    /// <inheritdoc />
    public partial class newcolAppointmentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Payments");
        }
    }
}
