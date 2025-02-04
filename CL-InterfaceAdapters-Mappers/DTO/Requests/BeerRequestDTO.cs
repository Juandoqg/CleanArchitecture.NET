using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_InterfaceAdapters_Mappers.DTO.Requests
{
    public class BeerRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }

        public decimal Alcohol { get; set; }
    }
}
