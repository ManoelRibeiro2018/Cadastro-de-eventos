using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MinLength(4)]
        [MaxLength(50)]
        public string Tema { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [Range(1, 12000, ErrorMessage = "Quatidade de pessoas deve está entre 1 à 12000")]
        public int QtdPessoas { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
