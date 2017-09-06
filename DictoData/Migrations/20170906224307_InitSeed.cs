using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DictoData.Migrations
{
    public partial class InitSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Roles(Id,Name,Created) values(1,'Administrator','2017-09-06T23:26:28Z')");
            migrationBuilder.Sql("insert into Roles(Id,Name,Created) values(2,'User','2017-09-06T23:26:28Z')");
            
            // coolpassword
            migrationBuilder.Sql("insert into Users(Id,Email,FirstName,LastName,Password,RoleId,Created) values(1,'admin@admin.com','Yariki','Yariki','995ddff75421a80c6b932292422ab336',1,'2017-09-06T23:26:28Z')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
