using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerToPokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Counties_OriginId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Owners_OwnerId",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "type2",
                table: "Pokemons",
                newName: "Type2");

            migrationBuilder.RenameColumn(
                name: "type1",
                table: "Pokemons",
                newName: "Type1");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Pokemons",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pokemons",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Pokemons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Owners",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Counties_OriginId",
                table: "Owners",
                column: "OriginId",
                principalTable: "Counties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Owners_OwnerId",
                table: "Pokemons",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Counties_OriginId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Owners_OwnerId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "Type2",
                table: "Pokemons",
                newName: "type2");

            migrationBuilder.RenameColumn(
                name: "Type1",
                table: "Pokemons",
                newName: "type1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pokemons",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pokemons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Owners",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Counties_OriginId",
                table: "Owners",
                column: "OriginId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Owners_OwnerId",
                table: "Pokemons",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
