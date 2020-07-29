using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidosRumo.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Cliente { get; set; }

        public List<PedidoAuxiliar> pedidoAuxiliar { get; set; }
    }
}
