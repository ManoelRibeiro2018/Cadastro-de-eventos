using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.DTO
{
    public class EventoDTO
    {
        
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
     
    }
}
