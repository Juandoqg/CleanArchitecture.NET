using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_InterfaceAdapters_Presenters
{
    public class BeerPresenter : IPresenter<Beer, BeerViewModel>
    {
        public IEnumerable<BeerViewModel> Present(IEnumerable<Beer> beers)
        {
            return beers.Select(b => new BeerViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Alcohol = b.Alcohol + "%"
            });
        }
    }
}
