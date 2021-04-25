﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImageUrl { get; set; }
    }
}
