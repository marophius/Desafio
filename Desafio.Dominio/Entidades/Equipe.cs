using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Dominio.Entidades
{
    public class Equipe
    {
        public int Id { get; set; }
        public string NomeEquipe { get; set; }
        public string NomeGestor { get; set; }

        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
