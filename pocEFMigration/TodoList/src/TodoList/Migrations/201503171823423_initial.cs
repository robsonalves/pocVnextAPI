using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace TodoList.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn("AspNetUsers", "NormalizedEmail", c => c.String());
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn("AspNetUsers", "NormalizedEmail");
        }
    }
}