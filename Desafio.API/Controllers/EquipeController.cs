using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.API.Validacoes;
using Desafio.Dominio.Entidades;
using Desafio.Respositorio.Repositorios.Contratos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        /*
         * Dentro do controlador, temos os métodos de atualizar e cadastrar
         * que é onde se encontram as validações do Fluent, passando pela validação
         * as model serão inseridas no contexto pelo repositório.
         */
        private readonly IEquipeRepository _equipeRepository;
        private EquipeValidator _equipeValidator;
        private ValidationResult _validationResult;

        public EquipeController(IEquipeRepository equipeRepository, EquipeValidator equipeValitation, ValidationResult validationResult)
        {
            _equipeRepository = equipeRepository;
            _equipeValidator = equipeValitation;
            _validationResult = validationResult;
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
                _validationResult = _equipeValidator.Validate(equipe);
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
                _validationResult = _equipeValidator.Validate(equipe);
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
        public IActionResult ObterEquipe(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Código Inválido");
            }

            _equipeRepository.ObterEquipe(id);

            return Ok();
        }

        
    }
}
