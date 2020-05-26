using Microsoft.EntityFrameworkCore.Migrations;

namespace EsperiaHelp.Migrations
{
    public partial class ModifyingFK_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Classroom_ClassroomId",
                table: "Lesson");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Lesson",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Classroom_ClassroomId",
                table: "Lesson",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Classroom_ClassroomId",
                table: "Lesson");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Classroom_ClassroomId",
                table: "Lesson",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);*/
        }
    }
}
