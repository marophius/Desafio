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
    public class ColaboradorController : ControllerBase
    {
        private IColaboradorRepository _colaboradorRepositorio;

        public ColaboradorController(IColaboradorRepository cbRepos)
        {
            _colaboradorRepositorio = cbRepos;
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
        public Colaborador ObterColaborador(int id)
        {
            return _colaboradorRepositorio.ObterColaborador(id);
        }
    }
}
