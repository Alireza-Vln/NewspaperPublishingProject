using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperPublishing.Entities.NewspaperCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.NewspaperCategories
{
    public class NewspaperCategoryEntityMap : IEntityTypeConfiguration<NewspaperCategory>
    {
        public void Configure(EntityTypeBuilder<NewspaperCategory> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.CategoryId);
            builder.Property(_ => _.NewspaperId).ValueGeneratedOnAdd();
        }
    }
}
