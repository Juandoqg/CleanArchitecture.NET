using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using CL_InterfaceAdapters_Mappers.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_InterfaceAdapters_Mappers
{
    public class SaleMapper : IMapper<SaleRequestDTO, Sale>
    {
        public Sale toEntity(SaleRequestDTO dto)
        {
              
            var concepts = new List<Concept>();

            foreach ( var conceptDTo in dto.Concepts )
            {
                concepts.Add(new Concept(conceptDTo.Quantity, conceptDTo.IdBeer, conceptDTo.UnitPrice));
            }

            return new Sale (DateTime.Now, concepts);
        }
    }
}
