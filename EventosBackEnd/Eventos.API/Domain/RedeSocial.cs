using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Nome { get; set; }

        [Required]
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }

        public void Update( string nome, string url)
        {
            Nome = nome;
            URL = url;
        }
    }
}
