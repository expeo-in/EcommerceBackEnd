using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Users(email, password) values('admin@gmail.com', 'admin')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Users where email = 'admin@gmail.com'");
        }
    }
}
