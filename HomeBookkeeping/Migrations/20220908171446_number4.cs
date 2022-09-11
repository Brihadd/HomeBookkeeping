using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBookkeeping.Migrations
{
    public partial class number4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryCategoryID",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "CostCategoryCategoryID",
                table: "Expenses",
                newName: "CostCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CostCategoryCategoryID",
                table: "Expenses",
                newName: "IX_Expenses_CostCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "CostCategory",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryId",
                table: "Expenses",
                column: "CostCategoryId",
                principalTable: "CostCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "CostCategoryId",
                table: "Expenses",
                newName: "CostCategoryCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CostCategoryId",
                table: "Expenses",
                newName: "IX_Expenses_CostCategoryCategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CostCategory",
                newName: "CategoryID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CostCategory_CostCategoryCategoryID",
                table: "Expenses",
                column: "CostCategoryCategoryID",
                principalTable: "CostCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
