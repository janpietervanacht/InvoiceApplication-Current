using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NickNameNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Opmerking: We willen een not-nullable string kolom toevoegen
            // aan Clients.
            // Omdat Clients al gevuld was met records, moeten we de volgende stappen doorlopen
            // Stap 1. Voeg nullable kolom toe aan clients
            // Stap 2. Vul deze kolom met lege strings via een SSMS-query
            // Stap 3. Voer onderstaande migratie (*) uit
            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Clients",
                nullable: false,  // (*)
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
