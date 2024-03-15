using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperPublishing.Entities.NewspaperNewses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.NewspaperNewses
{
    public class NewspaperNewsEntityMap : IEntityTypeConfiguration<NewspaperNews>
    {
        public void Configure(EntityTypeBuilder<NewspaperNews> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.NewspaperId);
            builder.Property(_ => _.NewsId);
        }
    }
}
