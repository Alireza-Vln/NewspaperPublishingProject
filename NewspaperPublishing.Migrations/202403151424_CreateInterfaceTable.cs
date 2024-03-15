using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403151424)]
    public class _202403151424_CreateInterfaceTable : Migration
    {
        public override void Up()
        {
            Create.Table("NewspaperCategories")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("CategoryId").AsInt32()
                 .WithColumn("NewspaperId").AsInt32();
            
            Create.Table("NewsTags")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("TagId").AsInt32()
                 .WithColumn("NewsId").AsInt32();
            
            Create.Table("NewspaperNewses")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("NewsId").AsInt32()
                 .WithColumn("NewspaperId").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("NewspaperNewses");
            Delete.Table("NewsTags");
            Delete.Table("NewspaperCategories");
        }

       
    }
}
