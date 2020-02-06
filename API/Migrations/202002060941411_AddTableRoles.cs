namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableRoles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "TB_M_Roles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_M_Roles", newName: "Roles");
        }
    }
}
