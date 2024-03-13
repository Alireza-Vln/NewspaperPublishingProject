using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403121320)]
    public class _202403121320_CreateCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Title").AsString(50).NotNullable()
                 .WithColumn("Weight").AsInt32().Nullable()
                 .WithColumn("View").AsInt32()
                 .WithColumn("NewspaperId").AsInt32().Nullable();
        }
        public override void Down()
        {
            Delete.Table("Categories");
        }

       
    }
}
