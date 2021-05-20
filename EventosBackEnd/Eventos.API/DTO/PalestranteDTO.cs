using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.DTO
{
    public class PalestranteDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Nome { get; set; }

        [Required]
        public string MiniCurriculo { get; set; }

        [RegularExpression(@"(. Png | .jpg | .gif) $", ErrorMessage = "Imagem invalida")]
        public string ImagemUrl { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
