using FluentMigrator;

namespace Exercises.Migrations
{
    [Migration(201506231650)]
    public class M_2015_06_23_1650_Create_People : Migration
    {
        public override void Up()
        {
            Create.Table("People").WithDescription("All people in the world").InSchema("dbo")
                .WithColumn("Id").AsGuid().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("People").InSchema("dbo");
        }
    }

    [Migration(201506231700)]
    public class M_2015_06_23_1700_Add_Name_to_People : Migration
    {
        public override void Up()
        {
            Alter.Table("People").WithDescription("All people in the world").InSchema("dbo")
                .AddColumn("Name").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Column("Name")
                .FromTable("People").InSchema("dbo");
        }
    }
}