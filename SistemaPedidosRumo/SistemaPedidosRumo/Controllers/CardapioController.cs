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
    public class CardapioController : Controller
    {

        private SistemaContext db = new SistemaContext();

        // GET: CardapioController
        public ActionResult Index()
        {
            return View(db.Cardapio.ToList());
        }

        // GET: CardapioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cardapio cardapio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cardapio.Add(cardapio);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return View(cardapio);

            }
            catch
            {
                return View(cardapio);
            }
        }

        // GET: CardapioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var cardapio = db.Cardapio.Find(id);
                db.Cardapio.Remove(cardapio);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CardapioController/Pedido
        public ActionResult Pedido()
        {
            return RedirectToAction("Index", "Pedido");
        }
    }
}
