using System.Collections.Generic;
using CSV.Core.Model;

namespace CSV.application
{
    public interface ILogResolver
    {
        (List<Productavg>, List<PopularBrand>) Solve(List<Log> logs);
    }
}