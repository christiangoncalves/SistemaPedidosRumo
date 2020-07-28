using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidosRumo.Models
{
    public class PedidoAuxiliar
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdCardapio { get; set; }
        public int Qtde { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido pedido { get; set; }

        [ForeignKey("IdCardapio")]
        public Cardapio cardapio { get; set; }
    }
}
