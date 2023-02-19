using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);
    }
}
