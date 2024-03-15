using NewspaperPublishing.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewspaperPublishing.Infrastructure
{
    public class DateTimeAppService : DateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
