using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBookkeeping.Migrations
{
    public partial class number6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CostCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CostCategoryId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CostCategory_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "CostCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CostCategory_CategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "CostCategoryId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CostCategoryId",
                table: "Expenses",
                column: "CostCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryId",
                table: "Expenses",
                column: "CostCategoryId",
                principalTable: "CostCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
