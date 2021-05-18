using System;

namespace Eventos.API.DTO
{
    public class EventoViewModel
    {
        public EventoViewModel(int id, string local, DateTime dataEvento, string tema, int qtdPessoas, string imageUrl, string telefone, string email)
        {
            Id = id;
            Local = local;
            DataEvento = dataEvento;
            Tema = tema;
            QtdPessoas = qtdPessoas;
            ImageUrl = imageUrl;
            Telefone = telefone;
            Email = email;
        }

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
