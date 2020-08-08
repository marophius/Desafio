using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Dominio.Entidades
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
        public int EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
