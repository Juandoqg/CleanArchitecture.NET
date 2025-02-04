using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using CL_InterfaceAdapters_Mappers.DTO.Requests;

namespace CL_InterfaceAdapters_Mappers
{
    public class BeerMapper : IMapper<BeerRequestDTO,Beer>
    {
        public Beer toEntity(BeerRequestDTO dto)
        =>
            new Beer()
            {
                Id = dto.Id,
                Name = dto.Name,
                Style = dto.Style,
                Alcohol = dto.Alcohol,
            };
        
    }
}
