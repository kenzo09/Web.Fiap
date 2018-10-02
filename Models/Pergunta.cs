﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.Models
{
    public class Pergunta
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }
        public string Autor { get; set; }
    }
}
