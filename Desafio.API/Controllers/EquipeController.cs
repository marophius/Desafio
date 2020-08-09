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
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("obterTodas")]
        public List<Equipe> ObterTodasEquipes()
        {
            return _equipeRepository.ObterTodasEquipes().ToList();
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Equipe equipe)
        {
            // Equipe equipe = JsonConvert.DeserializeObject<Equipe>(equipeJsonString);
            try
            {
                _validationResult = _equipeValidator.Validate(equipe);

                if (!_validationResult.IsValid)
                {
                    foreach (var failure in _validationResult.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }

                _equipeRepository.Cadastrar(equipe);
                return Ok("Equipe cadastrada com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost()]
        [Route("atualizar")]
        public IActionResult Atualizar([FromBody] Equipe equipe)
        {
            try
            {
                _validationResult = _equipeValidator.Validate(equipe);

                if (!_validationResult.IsValid)
                {
                    foreach(var failure in _validationResult.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                _equipeRepository.Atualizar(equipe);

                return Ok("Registro atualizado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("excluir")]
        public IActionResult Excluir(Equipe equipe)
        {
            try
            {
                _equipeRepository.Excluir(equipe);

                return Ok("Registro apagado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("obterEquipe")]
        public IActionResult ObterEquipe(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Código Inválido");
            }

            _equipeRepository.ObterEquipe(id);

            return Ok();
        }

        [HttpPost]
        [Route("teste")]
        public IActionResult teste()
        {
            return Ok();
        }

        
    }
}
