using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauliMarineRes.Controllers
{
    public class SupplierController : BaseController
    {
        // GET: Supplier
        public ActionResult Index(int? page, string Name)
        {
            if (Name?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Supplier>(page, "Supplier where SupplierName like '%" + Name + "%'"));
        }

        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<Supplier>(id, "SupplierId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "SupplierId,SupplierName,Email,ContactName,ContactNo,Address")] Supplier item)
        {
            return base.BaseSave<Supplier>(item, item.SupplierId > 0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}