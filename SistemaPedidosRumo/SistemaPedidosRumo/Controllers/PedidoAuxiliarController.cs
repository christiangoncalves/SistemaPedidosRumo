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

        // GET: PedidoAuxiliarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoAuxiliarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoAuxiliarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoAuxiliarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Copa()
        {
            
            return View(insertCardapio());
        }

        public ActionResult Cozinha()
        {
            return View(insertCardapio());
        }

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
