using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauliMarineRes.Controllers
{
    public class TransactionsController : BaseController
    {
        // GET: Transactions
        public ActionResult Index(int? id)
        {
            ViewBag.Transactions = db.Query<Transactionvw>("Select t.TicketNo,u.UnitId,u.UnitName,vc.VeichleId,vc.VeichleNumber, " +
                "t.LoadedWeight,t.EmptyWeight,t.NetWeight,su.SupplierId,su.SupplierName,mt.MaterialId,mt.MaterialName,t.RecievedAmt,t.Tdate from Transactions t " +
                "inner join Units u on u.UnitId=t.UnitId " +
                "inner join VeichleEntry vc on vc.VeichleId=t.VeichleId " +
                "inner join Supplier su on su.SupplierId=t.SupplierId " +
                "inner join Material mt on mt.MaterialId=t.MaterialId");
            ViewBag.VeichleNumber = db.SingleOrDefault<string>("Select VeichleNumber from VeichleEntry where VeichleId=@0", id);
            ViewBag.VeichleId = id;
            ViewBag.UnitId = new SelectList(db.Fetch<Unit>("Select UnitId,UnitName from Units"), "UnitId", "UnitName");
            ViewBag.SupplierId = new SelectList(db.Fetch<Supplier>("Select SupplierId,SupplierName from Supplier"), "SupplierId", "SupplierName");
            ViewBag.MaterialId = new SelectList(db.Fetch<Material>("Select MaterialId,MaterialName from Material"), "MaterialId", "MaterialName");
            return View("Index");
        }

        public ActionResult Manage(int? id)
        {
            ViewBag.UnitId = new SelectList(db.Fetch<Unit>("Select UnitId,UnitName from Units"), "UnitId", "UnitName");
            ViewBag.SupplierId = new SelectList(db.Fetch<Supplier>("Select SupplierId,SupplierName from Supplier"), "SupplierId", "SupplierName");
            ViewBag.MaterialId = new SelectList(db.Fetch<Material>("Select MaterialId,MaterialName from Material"), "MaterialId", "MaterialName");
            return View(base.BaseCreateEdit<Transaction>(id, "TicketNo"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage([Bind(Include = "TicketNo,UnitId,VeichleId,LoadedWeight,EmptyWeight,NetWeight,SupplierId,MaterialId,RecievedAmt,Tdate,Ttime")] Transaction item)
        {
            item.Tdate = DateTime.Now;
            return base.BaseSave<Transaction>(item, item.TicketNo > 0);
        }


        public ActionResult _ViewTransactions(int id)
        {
            var vwtrn = db.Query<Transactionvw>("Select t.TicketNo,u.UnitId,u.UnitName,vc.VeichleId,vc.VeichleNumber, " +
                "t.LoadedWeight,t.EmptyWeight,t.NetWeight,t.RecievedAmt,t.Tdate,su.SupplierId,su.SupplierName,mt.MaterialId,mt.MaterialName from Transactions t " +
                "inner join Units u on u.UnitId=t.UnitId " +
                "inner join VeichleEntry vc on vc.VeichleId=t.VeichleId " +
                "inner join Supplier su on su.SupplierId=t.SupplierId " +
                "inner join Material mt on mt.MaterialId=t.MaterialId where TicketNo = @0", id);
            return View(vwtrn);
        }

        public PartialViewResult _AddVehicleEntry()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageVehicle([Bind(Include = "VeichleId,VeichleNumber")] VeichleEntry item)
        {
            return base.BaseSave<VeichleEntry>(item, item.VeichleId > 0);
        }

        public ActionResult AutoCompleteVeichles(string term)
        {
            var filteredItems = db.Fetch<VeichleEntry>($"Select VeichleId,VeichleNumber from VeichleEntry where VeichleNumber like '%{term}%'").Select(c => new { id = c.VeichleId, value = c.VeichleNumber });
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

    }
}