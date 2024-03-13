using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403121328)]
    public class _202403121328_CreateTagTable : Migration
    {
       

        public override void Up()
        {
            Create.Table("Tags")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("CategoryId").AsInt32().ForeignKey("FK_Tags_Categories", "Categories", "Id")
                .WithColumn("NewsId").AsInt32();
           
        }
        public override void Down()
        {
            Delete.Table("Tags");
        }
    }
}
