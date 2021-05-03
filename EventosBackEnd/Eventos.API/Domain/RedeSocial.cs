using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }

        public void Update(int id, string nome, string url, int eventoId, int? palestranteId)
        {
            Id = id;
            Nome = nome;
            URL = url;
            EventoId = eventoId;
            PalestranteId = palestranteId;
        }
    }
}
