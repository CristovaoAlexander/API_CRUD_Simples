using AutoMapper;
using CadastroAPP.API.DTOs;
using CadastroAPP.Data.Entities;
using CadastroAPP.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        //atributo para injecao do AutoMapper
        private readonly IMapper _mapper;

        public PessoaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(PessoaRequestDTO requestDTO)
        {
            try
            {
                //copia os campos da classe DTO para a entidade
                var pessoa = _mapper.Map<Pessoa>(requestDTO);
                //gera o ID
                pessoa.Id=Guid.NewGuid();

                //grava no banco
                var pessoaRepository = new PessoaRepository();
                pessoaRepository.Salvar(pessoa);

                // 201 created
                return StatusCode(201,
                    new {mensagem = "nome cadastrado" });
            }
            catch (Exception ex) 
            {
                return StatusCode(500,
                    new { mensagem = "falha ao cadastrar" + ex.Message});
            }
            
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PessoaRequestDTO requestDto)
        {
            try
            { 
                var pessoaRepository = new PessoaRepository(); 
                var pessoa = pessoaRepository.GetById(id);

                if (pessoa == null)
                    return StatusCode(404, new { mensagem = " nao localizado" });

                _mapper.Map(requestDto, pessoa);

                pessoaRepository.Update(pessoa);
                return StatusCode(200, new {mensagem = "atualizacao ok"});
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { mensagem = "erro ao executar atualização" + ex.Message });
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {           
            try
            {
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(id);

                if (pessoa == null)
                    return StatusCode(404, new { mensagem = "nao encontrato" });

                pessoaRepository.Delete(pessoa);
                return StatusCode(200, new { mensagem = "delete OK" });
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new { mensagem = "erro delete" + ex.Message});
            }
        }

        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    return Ok("pesquisa OK");
        //}

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                var pessoaRepository = new PessoaRepository();
                // uma lista
                var pessoas = pessoaRepository.GetAll();

                //usando AutoMapper para copiar os dados para o DTO
                var response = _mapper.Map<List<PessoaResponseDTO>>(pessoas);

                return StatusCode(200, response);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new {mensagem = "erro consulta" + ex.Message} );
            }           

        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pessoaRepository = new PessoaRepository();
                var pessoa = pessoaRepository.GetById(id);

                //verifica se localizou
                if(pessoa == null)
                    return StatusCode(204);

                //copiar dados para DTO
                var response = _mapper.Map<PessoaResponseDTO>(pessoa);  

                return StatusCode(200, response);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { mensagem = "erro pesquisa por ID " + ex.Message});
            }
        
        }

        [HttpGet("listanomes/{nome}")]
        public IActionResult TrechoNome(string nome)
        {
            try
            {
               var pessoaRepository =new PessoaRepository();
               var pessoa = pessoaRepository.GetByNomeLista(nome);

                if (pessoa == null)
                    return StatusCode(204, new {mensagem ="nao localizado"});

                var response = _mapper.Map<List<PessoaResponseDTO>>(pessoa);

                return StatusCode(200, response);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { mensagem = "erro pesquisa trecho nome" + ex.Message });
            }
        }

    }
}
