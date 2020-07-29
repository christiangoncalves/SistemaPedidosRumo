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

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
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

        public ActionResult Cardapio()
        {
            return RedirectToAction("Index", "Cardapio");
        }

        public ActionResult InsertItens(int id)
        {
            return RedirectToAction("Create", "PedidoAuxiliar", new { id = id });
        }

        public ActionResult Copa()
        {
            return RedirectToAction("Copa", "PedidoAuxiliar");
        }

        public ActionResult Cozinha()
        {
            return RedirectToAction("Cozinha", "PedidoAuxiliar");
        }
    }
}
