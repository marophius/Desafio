using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Dominio.Entidades;
using Desafio.Dominio.Validacoes;
using Desafio.Respositorio.Repositorios.Contratos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        /*
         * Dentro do controlador, temos os métodos de atualizar e cadastrar
         * que é onde se encontram as validações do Fluent, passando pela validação
         * as model serão inseridas no contexto pelo repositório.
         */
        private IColaboradorRepository _colaboradorRepositorio;
        private ColaboradorValidator _colaboradorValidator;
        private ValidationResult _validationResult;

        public ColaboradorController(IColaboradorRepository cbRepos, ColaboradorValidator colaboradorValidation, ValidationResult validationResult)
        {
            _colaboradorRepositorio = cbRepos;
            _colaboradorValidator = colaboradorValidation;
            _validationResult = validationResult;
        }

        [HttpGet("api/colaborador/obterTodos")]
        public List<Colaborador> ObterTodosColaboradores()
        {
            return _colaboradorRepositorio.ObterTodosColaboradores().ToList();
        }

        [HttpPost("api/colaborador/cadastrar")]
        public IActionResult Cadastrar([FromBody] Colaborador colaborador)
        {
            try
            {
                _validationResult = _colaboradorValidator.Validate(colaborador);
                /*
                 * Embora não tenha sido pedido, eu creio que seria estranho caso fosse possível
                 * cadastrar alguém muito novo para trabalhar, então fiz essa ultima validação aqui;
                 */
                var colaboradorIdade = colaborador.DataNascimento;
                var today = DateTime.Now;
                var validaçãoIdade = colaborador.DataNascimento.Year - today.Year;

                if(colaboradorIdade > today.AddYears(-validaçãoIdade) && validaçãoIdade > 18)
                {
                    return BadRequest("Idade inválida!");
                }
                _colaboradorRepositorio.Cadastrar(colaborador);
                return Ok("Cadastrado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("api/colaborador/atualizar")]
        public IActionResult Atualizar([FromBody] Colaborador colaborador)
        { 
            try
            {
                _validationResult = _colaboradorValidator.Validate(colaborador);
                _colaboradorRepositorio.Atualizar(colaborador);
                return Ok("Atualizado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("api/colaborador/excluir")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _colaboradorRepositorio.Excluir(id);

                return Ok("Registro apagado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("api/colaborador/obterColaborador")]
        public IActionResult ObterColaborador(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Código inválido"); 
            }

            _colaboradorRepositorio.ObterColaborador(id);
            return Ok();
        }
    }
}
