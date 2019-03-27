using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauliMarineRes.Controllers
{
    public class UnitController : BaseController
    {
        // GET: Supplier
        public ActionResult Index(int? page, string Name)
        {
            if (Name?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Unit>(page, "Units where UnitName like '%" + Name + "%'"));
        }

        public ActionResult Manage(int? id)
        {
            return View(base.BaseCreateEdit<Unit>(id, "UnitId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "UnitId,UnitName")] Unit item)
        {
            return base.BaseSave<Unit>(item, item.UnitId > 0);
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