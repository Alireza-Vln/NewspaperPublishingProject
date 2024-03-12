using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperPublishing.Entities.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.Newses
{
    public class NewsEntityMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
         builder.HasKey(x => x.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Title).IsRequired();
            builder.Property(_=>_.AuthorId).IsRequired();
            builder.Property(_=>_.Weight).IsRequired();
            builder.Property(_ => _.Tags);
            builder.Property(_=>_.View);
            builder.Property(_ => _.NewspaperId);

        }
    }
}
