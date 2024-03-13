using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Migrations
{
    [Migration(202403131138)]
    public class _202403131138_AlterNewsTableForColumnCategoryId : Migration
    {
        public override void Up()
        {
            Alter.Table("Newses")

                .AddColumn("CategoryId").AsInt32();

        }
        public override void Down()
        {
            Delete.Column("CategoryId").FromTable("Newses");
        }

      
    }
}
