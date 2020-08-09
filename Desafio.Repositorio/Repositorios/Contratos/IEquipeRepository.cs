using Desafio.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Respositorio.Repositorios.Contratos
{
    public interface IEquipeRepository
    {
        // Aqui a interface de equipe com seus métodos de crud
        void Cadastrar(Equipe equipe);
        void Atualizar(Equipe equipe);
        void Excluir(Equipe equipe);
        Equipe ObterEquipe(int id);
        IEnumerable<Equipe> ObterTodasEquipes();
    }
}
