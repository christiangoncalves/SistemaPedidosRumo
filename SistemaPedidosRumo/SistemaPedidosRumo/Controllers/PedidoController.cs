using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidosRumo.Context;
using SistemaPedidosRumo.Models;

namespace SistemaPedidosRumo.Controllers
{
    public class PedidoController : Controller
    {
        private SistemaContext db = new SistemaContext();

        // GET: PedidoController
        public ActionResult Index()
        {
            return View(db.Pedido.ToList());
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Pedido.Add(pedido);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return View(pedido);
            }
            catch
            {
                return View(pedido);
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var pedido = db.Pedido.Find(id);
                db.Pedido.Remove(pedido);
                db.SaveChanges();
                return RedirectToAction("DeletePedido", "PedidoAuxiliar", new { id = pedido.Id });
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PedidoController/Cardapio
        public ActionResult Cardapio()
        {
            return RedirectToAction("Index", "Cardapio");
        }

        // GET: PedidoController/InsertItens
        public ActionResult InsertItens(int id)
        {
            return RedirectToAction("Create", "PedidoAuxiliar", new { id = id });
        }

        // GET: PedidoController/Copa

        public ActionResult Copa()
        {
            return RedirectToAction("Copa", "PedidoAuxiliar");
        }

        // GET: PedidoController/Cozinha

        public ActionResult Cozinha()
        {
            return RedirectToAction("Cozinha", "PedidoAuxiliar");
        }
    }
}
