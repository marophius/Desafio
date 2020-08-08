using Desafio.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Respositorio.Repositorios.Contratos
{
    public interface IEquipeRepository
    {
        void Cadastrar(Equipe equipe);
        void Atualizar(Equipe equipe);
        void Excluir(int id);
        Equipe ObterEquipe(int id);
        IEnumerable<Equipe> ObterTodasEquipes();
    }
}
