using CL_ApplicationLayer.Exceptions;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_ApplicationLayer
{
    public class AddBeerUseCase <TDTO>
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IMapper<TDTO, Beer> _mapper;

        public AddBeerUseCase(IRepository<Beer> beerRepository, IMapper<TDTO, Beer> Mapper)
        {
            _beerRepository = beerRepository;
            _mapper = Mapper;
        }

        public async Task ExecuteAsync (TDTO beerDTO)
        {
            var beer = _mapper.toEntity(beerDTO);   

            if(string.IsNullOrEmpty(beer.Name))
            {
                throw new ValidationException("El nombre de la cerveza es obligatorio ");
            }
            await _beerRepository.AddAsync(beer);
        }



    }
}
