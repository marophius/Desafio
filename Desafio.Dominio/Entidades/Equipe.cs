using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Dominio.Entidades
{
    public class Equipe
    {
        /*
         * Aqui estão as models que foram requisitadas no desafio,
         * caso haja algum atributo que exceda o que foi requisitado,
         * provavelmente é por seguir o padrão do entity framework
         * para colocar um relacionamento entre as Entidades
         */
        public int Id { get; set; }
        public string NomeEquipe { get; set; }
        public string NomeGestor { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
