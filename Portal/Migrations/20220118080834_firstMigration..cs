using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.SubmissionID);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    RowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    SubmissionsSubmissionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.RowID);
                    table.ForeignKey(
                        name: "FK_Answers_Submissions_SubmissionsSubmissionID",
                        column: x => x.SubmissionsSubmissionID,
                        principalTable: "Submissions",
                        principalColumn: "SubmissionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SubmissionsSubmissionID",
                table: "Answers",
                column: "SubmissionsSubmissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Submissions");
        }
    }
}
