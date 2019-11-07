using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_SalesDatabase.Migrations
{
    public partial class SalesAddDateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Sql("ALTER TABLE Sales ADD CONSTRAINT DefaultDateTime DEFAULT GETDATE() FOR Date");
        }

        private void Sql(string v)
        {
            throw new NotImplementedException();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
