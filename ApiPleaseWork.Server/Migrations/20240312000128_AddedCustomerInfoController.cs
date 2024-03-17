using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPleaseWork.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomerInfoController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInformation",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformation", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustCallAttempts",
                columns: table => new
                {
                    CallAttemptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfAttempt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerInformationCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustCallAttempts", x => x.CallAttemptId);
                    table.ForeignKey(
                        name: "FK_CustCallAttempts_CustomerInformation_CustomerInformationCustomerId",
                        column: x => x.CustomerInformationCustomerId,
                        principalTable: "CustomerInformation",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerContact",
                columns: table => new
                {
                    CustomerContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerInformationCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContact", x => x.CustomerContactId);
                    table.ForeignKey(
                        name: "FK_CustomerContact_CustomerInformation_CustomerInformationCustomerId",
                        column: x => x.CustomerInformationCustomerId,
                        principalTable: "CustomerInformation",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustCallAttempts_CustomerInformationCustomerId",
                table: "CustCallAttempts",
                column: "CustomerInformationCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_CustomerInformationCustomerId",
                table: "CustomerContact",
                column: "CustomerInformationCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustCallAttempts");

            migrationBuilder.DropTable(
                name: "CustomerContact");

            migrationBuilder.DropTable(
                name: "CustomerInformation");
        }
    }
}
