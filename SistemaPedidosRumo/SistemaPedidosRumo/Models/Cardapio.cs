﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidosRumo.Models
{
    public class Cardapio
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int LocalCriacao { get; set; }
    }
}
