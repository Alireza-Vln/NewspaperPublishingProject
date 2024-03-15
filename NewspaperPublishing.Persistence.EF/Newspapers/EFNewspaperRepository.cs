using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.Newspapers
{
    public class EFNewspaperRepository : NewspaperRepository
    {
        readonly DbSet<Newspaper> _newspaper;
       
        public EFNewspaperRepository(EFDataContext context)
        {
            _newspaper = context.Newspapers;
           
        }

        public void Add(Newspaper newspaper)
        {
            _newspaper.Add(newspaper);
        }

       
    }
}
