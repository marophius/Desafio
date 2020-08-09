using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Dominio.Entidades;

namespace Desafio.Respositorio.Repositorios.Contratos
{
    public interface IColaboradorRepository
    {
        /*
         * Aqui estão as nossas interfaces, seguindo o padrão repositório
         */
        void Cadastrar(Colaborador cb);
        void Atualizar(Colaborador cb);
        void Excluir(Colaborador cb);
        Colaborador ObterColaborador(int id);
        IEnumerable<Colaborador> ObterTodosColaboradores();
    }
}
