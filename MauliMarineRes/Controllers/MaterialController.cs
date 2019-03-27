using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauliMarineRes.Controllers
{
    public class MaterialController : BaseController
    {
        // GET: Material
        public ActionResult Index(int? page, string Name)
        {
            if (Name?.Length > 0) page = 1;
            return View("Index", base.BaseIndex<Materialvw>(page, "mt.MaterialId,mt.MaterialName,mt.Quantity,u.UnitId,u.UnitName ", "Material mt,Units u where mt.UnitId=u.UnitId and MaterialName like '%" + Name + "%'"));
        }

        public ActionResult Manage(int? id)
        {
            ViewBag.UnitId = new SelectList(db.Fetch<Unit>("Select UnitId,UnitName from Units"), "UnitId", "UnitName");
            return View(base.BaseCreateEdit<Material>(id, "MaterialId"));
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "MaterialId,MaterialName,Quantity,UnitId")] Material item)
        {
            return base.BaseSave<Material>(item, item.MaterialId > 0);
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