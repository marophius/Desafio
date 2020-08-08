﻿using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Dominio.Entidades;

namespace Desafio.Respositorio.Repositorios.Contratos
{
    public interface IColaboradorRepository
    {
        void Cadastrar(Colaborador cb);
        void Atualizar(Colaborador cb);
        void Excluir(int id);
        Colaborador ObterColaborador(int id);
        IEnumerable<Colaborador> ObterTodosColaboradores();
    }
}