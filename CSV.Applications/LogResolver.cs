


using CSV.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.application
{


    public class LogResolver : ILogResolver
    {





        public (List<Productavg>, List<PopularBrand>) Solve(List<Log> logs)
        {
            Dictionary<string, int> prodcuts = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> Brands = new Dictionary<string, Dictionary<string, int>>();
            logs.ForEach(l =>
            {
                if (prodcuts.ContainsKey(l.Name))
                    prodcuts[l.Name] += l.Quantity;
                else prodcuts[l.Name] = l.Quantity;

                if (Brands.ContainsKey(l.Name))
                {
                    if (Brands[l.Name].ContainsKey(l.Brand))
                        Brands[l.Name][l.Brand]++;
                    else Brands[l.Name][l.Brand] = 1;

                }
                else
                {
                    Brands[l.Name] = new Dictionary<string, int>();
                    Brands[l.Name][l.Brand] = 1;
                }

            });

            var ProdcutsAVG = new List<Productavg>();
            foreach (var item in prodcuts)
            {
                ProdcutsAVG.Add(new Productavg { Name = item.Key, Average = (decimal)item.Value / logs.Count });

            }
            // Write<Productavg>("0_input_file_name.csv", ProdcutsAVG);

            var popularBrand = new List<PopularBrand>();
            foreach (var item in Brands)
            {

                popularBrand.Add(new PopularBrand { Prodcut = item.Key, Brand = item.Value.MaxBy(c => c.Value).Key });
            }

            // Write<PopularBrand>("1_input_file_name.csv", popularBrand);

            return (ProdcutsAVG, popularBrand);
        }


    }
}

