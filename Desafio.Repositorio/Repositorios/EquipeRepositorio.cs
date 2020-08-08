using Desafio.Dominio.Entidades;
using Desafio.Repositorio.Database;
using Desafio.Respositorio.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Respositorio.Repositorios
{
    public class EquipeRepositorio : IEquipeRepository
    {
        private readonly DesafioContext _context;

        public EquipeRepositorio(DesafioContext context)
        {
            _context = context;
        }

        public void Atualizar(Equipe equipe)
        {
            _context.Update(equipe);
            _context.SaveChanges();
        }

        public void Cadastrar(Equipe equipe)
        {
            _context.Add(equipe);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Equipe equipe = ObterEquipe(id);
            _context.Remove(equipe);
            _context.SaveChanges();
        }

        public Equipe ObterEquipe(int id)
        {
            return _context.Equipes.Find(id);
        }

        public IEnumerable<Equipe> ObterTodasEquipes()
        {
            return _context.Equipes.ToList();
        }
    }
}
