using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class Lote
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public void Update(string nome, decimal preco, DateTime dataInicio, DateTime dataFim, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Quantidade = quantidade;

        }
    }
}
