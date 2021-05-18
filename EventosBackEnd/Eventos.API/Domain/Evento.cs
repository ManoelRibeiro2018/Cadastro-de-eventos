using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public DateTime DataEvento { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Tema { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [Range(1,12000, ErrorMessage ="Quatidade de pessoas deve está entre 1 à 12000")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@"((.Png | .jpg | .gif) $", ErrorMessage = "Imagem invalida") ]
        public string ImageUrl { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial>  RedesSociais { get; set; }
        public List<Palestrante> Palestrantes { get; set; }

        public void Update(string local, DateTime dataEvento, string tema, int qtdPessoas, string imageUrl,string telefone, string email)
        {
            Local = local;
            DataEvento = dataEvento;
            Tema = tema;
            QtdPessoas = qtdPessoas;
            ImageUrl = imageUrl;
            Telefone = telefone;
            Email = email;
        }
    }
}
