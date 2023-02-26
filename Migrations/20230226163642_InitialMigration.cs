using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEFIRST.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipCategories",
                columns: table => new
                {
                    Membership_Category_Id = table.Column<int>(type: "int", nullable: false),
                    Membership_Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipCategories", x => x.Membership_Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Person_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Person_Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipsRecord",
                columns: table => new
                {
                    Membership_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Person_Id = table.Column<int>(type: "int", nullable: false),
                    Membership_Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipsRecord", x => x.Membership_Id);
                    table.ForeignKey(
                        name: "FK_MembershipsRecord_MembershipCategories_Membership_Category_Id",
                        column: x => x.Membership_Category_Id,
                        principalTable: "MembershipCategories",
                        principalColumn: "Membership_Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipsRecord_PersonDetails_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "PersonDetails",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MembershipCategories",
                columns: new[] { "Membership_Category_Id", "Membership_Category_Name" },
                values: new object[,]
                {
                    { 1, "Silver" },
                    { 2, "Gold" },
                    { 3, "Platinum" },
                    { 4, "Diamond" }
                });

            migrationBuilder.InsertData(
                table: "PersonDetails",
                columns: new[] { "Person_Id", "EmailId", "FirstName", "LastName" },
                values: new object[] { 1, "prasanna7567@gmail.com", "Prasanna", "Dhamal" });

            migrationBuilder.InsertData(
                table: "MembershipsRecord",
                columns: new[] { "Membership_Id", "Account_Balance", "Membership_Category_Id", "Person_Id" },
                values: new object[] { 1, 1000m, 2, 1 });

            migrationBuilder.InsertData(
                table: "MembershipsRecord",
                columns: new[] { "Membership_Id", "Account_Balance", "Membership_Category_Id", "Person_Id" },
                values: new object[] { 2, 1000m, 1, 1 });

            migrationBuilder.InsertData(
                table: "MembershipsRecord",
                columns: new[] { "Membership_Id", "Account_Balance", "Membership_Category_Id", "Person_Id" },
                values: new object[] { 3, 1000m, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipsRecord_Membership_Category_Id",
                table: "MembershipsRecord",
                column: "Membership_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipsRecord_Person_Id",
                table: "MembershipsRecord",
                column: "Person_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipsRecord");

            migrationBuilder.DropTable(
                name: "MembershipCategories");

            migrationBuilder.DropTable(
                name: "PersonDetails");
        }
    }
}
