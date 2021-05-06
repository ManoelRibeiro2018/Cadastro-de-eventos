using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo  { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public List<Evento> Eventos { get; set; }

        public void Update(string nome, string minicurriculo, string imageUrl, string telefone, string email)
        {
            Nome = nome;
            MiniCurriculo = minicurriculo;
            ImagemUrl = imageUrl;
            Telefone = telefone;
            Email = email;
        } 
    }
}
