using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Dominio.Entidades;
using Desafio.Respositorio.Repositorios.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeController(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        [HttpGet("api/equipe/obterTodasEquipes")]
        public List<Equipe> ObterTodasEquipes()
        {
            return _equipeRepository.ObterTodasEquipes().ToList();
        }

        [HttpPost("api/equipe/cadastrar")]
        public IActionResult Cadastrar([FromBody] Equipe equipe)
        {
            try
            {
                _equipeRepository.Cadastrar(equipe);
                return Ok("Equipe cadastrada com sucesso");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("api/equipe/atualizar")]
        public IActionResult Atualizar([FromBody] Equipe equipe)
        {
            try
            {
                _equipeRepository.Atualizar(equipe);

                return Ok("Registro atualizado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("api/equipe/excluir")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _equipeRepository.Excluir(id);

                return Ok("Registro apagado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("api/equipe/obterEquipe")]
        public Equipe ObterEquipe(int id)
        {
            return _equipeRepository.ObterEquipe(id);
        }

        
    }
}
