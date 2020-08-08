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

        public void Excluir(int id)
        {
            Colaborador cb = ObterColaborador(id);
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
