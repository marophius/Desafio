using Desafio.Dominio.Entidades;
using Desafio.Repositorio.Database;
using Desafio.Respositorio.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Respositorio.Repositorios
{
    public class ColaboradorRepositorio : IColaboradorRepository
    {
        /*
         * Aqui nossas implementações dos métodos de nossos contratos
         * PS.:Não fiz validações por aqui, as validações estão no projeto
         * da API dentro da pasta Validacoes
         */
        private readonly DesafioContext _context;

        public ColaboradorRepositorio(DesafioContext context)
        {
            _context = context;
        }

        public void Atualizar(Colaborador cb)
        {
            _context.Update(cb);
            _context.SaveChanges();
        }

        public void Cadastrar(Colaborador cb)
        {
            _context.Add(cb);
            _context.SaveChanges();
        }

        public void Excluir(Colaborador cb)
        {
            _context.Remove(cb);
            _context.SaveChanges();
        }

        public Colaborador ObterColaborador(int id)
        {
            return _context.Colaboradores.Find(id);
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            return _context.Colaboradores.ToList();
        }
    }
}
