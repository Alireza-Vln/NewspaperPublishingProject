using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403121418)]
    public class _202403121418_CreateNewsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Newses")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("AuthorId").AsInt32()
                .WithColumn("View").AsInt32()
                .WithColumn("CategoryId").AsInt32()
                .WithColumn("Weight").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Newses");
        }


    }
}
