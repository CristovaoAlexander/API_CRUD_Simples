using AutoMapper;
using CadastroAPP.API.DTOs;
using CadastroAPP.Data.Entities;

namespace CadastroAPP.API.Mappings
{/// <summary>
/// mapeamento entre as classes de entidades e DTO
/// </summary>
    public class ProfileMap :Profile
    {
        //metodo constrfutor ctor + tab
        public ProfileMap()
        {
            CreateMap<Data.Entities.Pessoa, PessoaResponseDTO>();
            CreateMap<PessoaRequestDTO, Data.Entities.Pessoa>();
        }
    }
}
