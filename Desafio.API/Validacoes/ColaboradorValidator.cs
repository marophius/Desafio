using System;
using System.Collections.Generic;
using System.Text;
using Desafio.Dominio.Entidades;
using FluentValidation;

namespace Desafio.Dominio.Validacoes
{
    public class ColaboradorValidator : AbstractValidator<Colaborador>
    {
        /*
         * Essa é a classe de validação do colaborador,
         * quando a gente usa ASP.NET MVC, temos validações
         * com o DataNotations, mas numa camada de domínio,
         * não é que não seja possível usar, mas que é recomendável
         * não usar, então usando a biblioteca FluentValidation,
         * fazemos nossas validações aqui.
         */
        public ColaboradorValidator()
        {
            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("Endereço é um campo obrigatório, não pode ser vazio!")
                .NotEmpty()
                .WithMessage("Endereço é um campo obrigatório, e não pode ser vazio!");
            RuleFor(c => c.DataNascimento)
                .NotNull().WithMessage("Data é um campo obrigatório e não pode ser vazio!")
                .NotEmpty().WithMessage("Data é um campo obrigatório e não pode ser vazio!");

            //Eu tentei trabalhar com o DateTime, porém não consegui.
            //RuleFor(c => c.DataNascimento)
            //    .NotNull()
            //    .WithMessage("A data é um campo obrigatório e não pode ser nulo!")
            //    .GreaterThan(DateTime.Today).WithMessage("Data inválida!");

            /*
             * No caso abaixo, poucos usuarios saberâo a diferença entre nulo e vazio,
             * embora que caso o usuário esteja fazendo um dos dois, não muda que ele
             * esteja cometendo um erro, mas eu preferi deixar a mesma mensagem para os 2
             */
            RuleFor(c => c.Genero)
                .NotNull().WithMessage("Gênero é um campo obrigatório, não pode ser vazio!")
                .NotEmpty().WithMessage("Gênero é um campo obrigatório, não pode ser vazio!");
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone é um campo obritário, não pode ser vazio")
                .NotNull().WithMessage("Telefone é um campo obrigatório, não pode ser vazio");
        }
    }
}
