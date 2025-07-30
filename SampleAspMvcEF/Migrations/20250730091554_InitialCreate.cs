using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleAspMvcEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    BasePrice = table.Column<double>(type: "float", nullable: true),
                    Color = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Car__68A0340E77F06A5D", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CardID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8E6A3B661", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    DealerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dealer__CA2F8E92D9559A98", x => x.DealerID);
                });

            migrationBuilder.CreateTable(
                name: "DealerCar",
                columns: table => new
                {
                    DealerCarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    DealerID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: true),
                    FeePercent = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DealerCa__7DD0B566538D77B1", x => x.DealerCarID);
                    table.ForeignKey(
                        name: "FK__DealerCar__CarID__628FA481",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID");
                    table.ForeignKey(
                        name: "FK__DealerCar__Deale__6383C8BA",
                        column: x => x.DealerID,
                        principalTable: "Dealer",
                        principalColumn: "DealerID");
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SalesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DealerID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SalesPer__C952FB1235E0F6CE", x => x.SalesID);
                    table.ForeignKey(
                        name: "FK__SalesPers__Deale__66603565",
                        column: x => x.DealerID,
                        principalTable: "Dealer",
                        principalColumn: "DealerID");
                });

            migrationBuilder.CreateTable(
                name: "LetterOfIntent",
                columns: table => new
                {
                    LoiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerCarID = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: true),
                    FeeAmount = table.Column<double>(type: "float", nullable: true),
                    FinalPrice = table.Column<double>(type: "float", nullable: false),
                    DownPayment = table.Column<double>(type: "float", nullable: true),
                    PaymentMethod = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LetterOf__412C029A7A1372A8", x => x.LoiID);
                    table.ForeignKey(
                        name: "FK__LetterOfI__Deale__4F7CD00D",
                        column: x => x.DealerCarID,
                        principalTable: "DealerCar",
                        principalColumn: "DealerCarID");
                });

            migrationBuilder.CreateTable(
                name: "ConsultHistory",
                columns: table => new
                {
                    ConsultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ConsultH__28859B15882A2E42", x => x.ConsultID);
                    table.ForeignKey(
                        name: "FK__ConsultHi__Custo__5FB337D6",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__ConsultHi__Sales__60A75C0F",
                        column: x => x.SalesPersonID,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesID");
                });

            migrationBuilder.CreateTable(
                name: "TestDrive",
                columns: table => new
                {
                    TestDriveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DealerCarID = table.Column<int>(type: "int", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    feedback = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestDriv__BF98EF728A76C646", x => x.TestDriveID);
                    table.ForeignKey(
                        name: "FK__TestDrive__Custo__68487DD7",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__TestDrive__Deale__6754599E",
                        column: x => x.DealerCarID,
                        principalTable: "DealerCar",
                        principalColumn: "DealerCarID");
                    table.ForeignKey(
                        name: "FK__TestDrive__Sales__693CA210",
                        column: x => x.SalesPersonID,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesID");
                });

            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    AgreementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: true),
                    LoiID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agreemen__0A309D232910C534", x => x.AgreementID);
                    table.ForeignKey(
                        name: "FK__Agreement__Custo__5CD6CB2B",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Agreement__LoiID__5441852A",
                        column: x => x.LoiID,
                        principalTable: "LetterOfIntent",
                        principalColumn: "LoiID");
                    table.ForeignKey(
                        name: "FK__Agreement__Sales__5EBF139D",
                        column: x => x.SalesPersonID,
                        principalTable: "SalesPerson",
                        principalColumn: "SalesID");
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreementID = table.Column<int>(type: "int", nullable: false),
                    CreditAmount = table.Column<double>(type: "float", nullable: false),
                    Tenor = table.Column<int>(type: "int", nullable: true),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    MonthlyPaymentAmount = table.Column<double>(type: "float", nullable: false),
                    CreditStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PaidFully = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Credit__ED5ED09B313A4DA0", x => x.CreditID);
                    table.ForeignKey(
                        name: "FK__Credit__Agreemen__619B8048",
                        column: x => x.AgreementID,
                        principalTable: "Agreement",
                        principalColumn: "AgreementID");
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreementID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentH__9B556A58E7EC8DDF", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__PaymentHi__Agree__656C112C",
                        column: x => x.AgreementID,
                        principalTable: "Agreement",
                        principalColumn: "AgreementID");
                });

            migrationBuilder.CreateTable(
                name: "WarrantyRegistration",
                columns: table => new
                {
                    WarrantyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    PurchaseID = table.Column<int>(type: "int", nullable: false),
                    WarrantyPeriodMonths = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warranty__2ED318F3EDE5B9B7", x => x.WarrantyID);
                    table.ForeignKey(
                        name: "FK__WarrantyR__CarID__6B24EA82",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID");
                    table.ForeignKey(
                        name: "FK__WarrantyR__Purch__6C190EBB",
                        column: x => x.PurchaseID,
                        principalTable: "Agreement",
                        principalColumn: "AgreementID");
                });

            migrationBuilder.CreateTable(
                name: "WarrantyClaim",
                columns: table => new
                {
                    ClaimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarrantyID = table.Column<int>(type: "int", nullable: false),
                    IssueReported = table.Column<string>(type: "text", nullable: false),
                    ServiceCenter = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RepairDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RepairCost = table.Column<double>(type: "float", nullable: false),
                    ClaimStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warranty__EF2E13BB5AEAA3B4", x => x.ClaimID);
                    table.ForeignKey(
                        name: "FK__WarrantyC__Warra__6A30C649",
                        column: x => x.WarrantyID,
                        principalTable: "WarrantyRegistration",
                        principalColumn: "WarrantyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_CustomerID",
                table: "Agreement",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_SalesPersonID",
                table: "Agreement",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "UQ__Agreemen__412C029BC5C303B4",
                table: "Agreement",
                column: "LoiID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultHistory_CustomerID",
                table: "ConsultHistory",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultHistory_SalesPersonID",
                table: "ConsultHistory",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "UQ__Credit__0A309D22EE83FE0C",
                table: "Credit",
                column: "AgreementID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealerCar_CarID",
                table: "DealerCar",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_DealerCar_DealerID",
                table: "DealerCar",
                column: "DealerID");

            migrationBuilder.CreateIndex(
                name: "IX_LetterOfIntent_DealerCarID",
                table: "LetterOfIntent",
                column: "DealerCarID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_AgreementID",
                table: "PaymentHistory",
                column: "AgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_DealerID",
                table: "SalesPerson",
                column: "DealerID");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_CustomerID",
                table: "TestDrive",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_DealerCarID",
                table: "TestDrive",
                column: "DealerCarID");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_SalesPersonID",
                table: "TestDrive",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyClaim_WarrantyID",
                table: "WarrantyClaim",
                column: "WarrantyID");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyRegistration_CarID",
                table: "WarrantyRegistration",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "UQ__Warranty__6B0A6BDFD401A47A",
                table: "WarrantyRegistration",
                column: "PurchaseID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultHistory");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropTable(
                name: "TestDrive");

            migrationBuilder.DropTable(
                name: "WarrantyClaim");

            migrationBuilder.DropTable(
                name: "WarrantyRegistration");

            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "LetterOfIntent");

            migrationBuilder.DropTable(
                name: "SalesPerson");

            migrationBuilder.DropTable(
                name: "DealerCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Dealer");
        }
    }
}
