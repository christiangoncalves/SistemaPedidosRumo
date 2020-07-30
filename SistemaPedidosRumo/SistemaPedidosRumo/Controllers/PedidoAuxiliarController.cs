using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaPedidosRumo.Context;
using SistemaPedidosRumo.Models;

namespace SistemaPedidosRumo.Controllers
{
    public class PedidoAuxiliarController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: PedidoAuxiliarController
        public ActionResult Index()
        {
            return RedirectToAction("index", "Pedido");

        }

        // GET: PedidoAuxiliarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoAuxiliarController/Create
        public ActionResult Create(int id)
        {
            ViewBag.itensCardapio = new SelectList(db.Cardapio, "Id", "Nome");
            ViewBag.idPedido = id;
            return View();
        }

        // POST: PedidoAuxiliarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoAuxiliar pedidoAuxiliar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PedidoAuxiliar.Add(pedidoAuxiliar);
                    db.SaveChanges();
                    return RedirectToAction("index", "Pedido");
                }

                return View(pedidoAuxiliar);
            }
            catch
            {
                return View(pedidoAuxiliar);
            }
        }

        // GET: PedidoAuxiliarController/DeleteCozinha/5
        public ActionResult DeleteCozinha(int id)
        {
            try
            {
                var pedido = db.PedidoAuxiliar.Find(id);
                db.PedidoAuxiliar.Remove(pedido);
                db.SaveChanges();

                return RedirectToAction(nameof(Cozinha));
            }
            catch
            {
                return RedirectToAction(nameof(Cozinha));
            }
        }

        // GET: PedidoAuxiliarController/DeleteCopa/5
        public ActionResult DeleteCopa(int id)
        {
            try
            {
                var pedido = db.PedidoAuxiliar.Find(id);
                db.PedidoAuxiliar.Remove(pedido);
                db.SaveChanges();

                return RedirectToAction(nameof(Copa));
            }
            catch
            {
                return RedirectToAction(nameof(Copa));
            }
        }

        // GET: PedidoAuxiliarController/DeletePedido/5
        /* Obs.: essa Action deleta todos os itens inseridos em um pedido ja deletado no PedidoController,
           tendo como parametro a id desse pedido */
        public ActionResult DeletePedido(int id)
        {
            try
            {
                var pedido = db.PedidoAuxiliar.ToList();
                foreach (var item in pedido)
                {
                    if(item.IdPedido == id)
                    {
                        db.PedidoAuxiliar.Remove(item);
                        db.SaveChanges();
                    }
                }


                return RedirectToAction("index", "Pedido");
            }
            catch
            {
                return RedirectToAction("index", "Pedido");
            }
        }

        // GET: PedidoAuxiliarController/Copa
        public ActionResult Copa()
        {
            
            return View(insertCardapio());
        }

        // GET: PedidoAuxiliarController/Cozinha
        public ActionResult Cozinha()
        {
            return View(insertCardapio());
        }

        //Metodo para inserir a instancia do item do Cardapio no objeto PedidoAuxiliar
        public List<PedidoAuxiliar> insertCardapio()
        {
            var pedidoAuxiliar = db.PedidoAuxiliar.ToList();
            foreach (var item in pedidoAuxiliar)
            {
                item.cardapio = db.Cardapio.Find(item.IdCardapio);
            }
            return pedidoAuxiliar;
        }

    }
}
