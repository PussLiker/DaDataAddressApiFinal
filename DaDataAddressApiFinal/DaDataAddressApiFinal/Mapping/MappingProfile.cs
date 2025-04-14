using AutoMapper;
using DaDataAddressApiFinal.Models;

namespace DaDataAddressApiFinal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<DaDataResult, AddressResponse>();
        }
    }
}
