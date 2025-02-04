using CL_ApplicationLayer.Exceptions;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_ApplicationLayer
{
    public class GenerateSaleUseCase <TDTO>
    {
        private IRepository<Sale> _repository;
        private readonly IMapper<TDTO, Sale> _mapper;

         public GenerateSaleUseCase(IRepository<Sale> repostitory, IMapper<TDTO, Sale> mapper)
        {
            _repository = repostitory;
            _mapper = mapper;
        }
           
        public async Task ExecuteAsync (TDTO saleDTO)
        {
            var sale = _mapper.toEntity(saleDTO);

            if (sale.Concepts.Count == 0)
            {
                throw new ValidationException("Una venta debe tener conceptos");
            }
            if (sale.Total <= 0)
            {
                throw new ValidationException("Una venta debe tener mas de $ 0.00 en total");
            }

            await _repository.AddAsync(sale);
        }




     }
}
