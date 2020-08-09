using Desafio.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Validacoes
{
    public class EquipeValidator : AbstractValidator<Equipe>
    {
        // Aqui estão as validações da model Equipe
        public EquipeValidator()
        {
            /*
             * Particularmente falando eu coloquei um tamanho mínimo para o nome da equipe
             * mais por colocar mesmo, eu não acho que seja uma boa colocar como nome de uma equipe
             * apenas uma letra, tipo "equipe A". Porém, isso fica a critério de vocês.
             */
            RuleFor(e => e.NomeEquipe)
                .NotNull().WithMessage("O nome da equipe é obrigatório!")
                .NotEmpty().WithMessage("O nome da equipe é obrigatório!")
                .MinimumLength(4).WithMessage("O nome da equipe deve ser maior");

            RuleFor(e => e.NomeGestor)
                .NotEmpty().WithMessage("O nome do gestor é obrigatório e não deve ser vazio")
                .NotNull().WithMessage("O nome do gestor é obrigatório e não deve ser vazio");
        }
    }
}
