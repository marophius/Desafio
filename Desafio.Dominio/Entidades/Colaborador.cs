using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Dominio.Entidades
{
    public class Colaborador
    {
        /*
         * Aqui estão as models que foram requisitadas no desafio,
         * caso haja algum atributo que exceda o que foi requisitado,
         * provavelmente é por seguir o padrão do entity framework
         * para colocar um relacionamento entre as Entidades
         */
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
        public int EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
