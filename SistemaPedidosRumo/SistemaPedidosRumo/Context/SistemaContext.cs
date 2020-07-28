using SistemaPedidosRumo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidosRumo.Context
{
    public class SistemaContext : DbContext
    {
        public DbSet<Cardapio>Cardapio { get; set; }
        public DbSet<Pedido>Pedido { get; set; }
        public DbSet<PedidoAuxiliar>PedidoAuxiliar { get; set; }

    }
}
