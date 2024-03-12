using FluentMigrator;


namespace NewspaperPublishing.Migrations
{
    [Migration(202403121412)]
    public class _202403121412_CreateAuthorTable : Migration
    {
       

        public override void Up()
        {
            Create.Table("Authors")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("FirstName").AsString(50).NotNullable()
                  .WithColumn("LastName").AsString(50).NotNullable()
                  .WithColumn("View").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("Authors");
        }
    }
}
