using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using CSV.Core.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.persistence
{
    

    public class LogMap : ClassMap<Log>
    {
        public LogMap()
        {
            Map(p => p.Id).Index(0);
            Map(p => p.Area).Index(1);
            Map(p => p.Name).Index(2);
            Map(p => p.Quantity).Index(3);
            Map(p => p.Brand).Index(4);
        }
    }
   
}

