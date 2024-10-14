using Adotion.App.DTO.AnimalDTO;
using Adotion.Business.Models;
using AutoMapper;

namespace Adotion.App.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        CreateMap<Animal, AnimalDTO>().ReverseMap();
        CreateMap<Adotante, AdotanteDTO>().ReverseMap();
    }
}