using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403121424)]
    public class _202403121424_CreateNewspaperTable : Migration
    {
        public override void Up()
        {
            Create.Table("Newspapers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Weight").AsInt32()
                .WithColumn("NewsId").AsInt32()
                .WithColumn("Date").AsDate();
        }
        public override void Down()
        {
            Delete.Table("Newspapers");
        }

      
    }
}
