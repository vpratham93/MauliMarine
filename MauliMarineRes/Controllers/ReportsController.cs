using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MauliMarineRes.Controllers
{
    public class ReportsController : BaseController
    {
        // GET: Reports
        public ActionResult Index(int? VehicleId, int? ticketno, int? SupplierId, int? MaterialId)
        {
            ViewBag.MaterialId = new SelectList(db.Fetch<Material>("Select MaterialId,MaterialName from Material"), "MaterialId", "MaterialName");
            ViewBag.SupplierId = new SelectList(db.Fetch<Supplier>("Select SupplierId,SupplierName from Supplier"), "SupplierId", "SupplierName");
            ViewBag.VehicleId = new SelectList(db.Fetch<VeichleEntry>("Select VeichleId,VeichleNumber from VeichleEntry"), "VeichleId", "VeichleNumber");
            PetaPoco.Sql sq = new PetaPoco.Sql("Select t.TicketNo,u.UnitId,u.UnitName,vc.VeichleId,vc.VeichleNumber, " +
                "t.LoadedWeight,t.EmptyWeight,t.NetWeight,t.RecievedAmt,t.Tdate,su.SupplierId,su.SupplierName,mt.MaterialId,mt.MaterialName from Transactions t " +
                "inner join Units u on u.UnitId=t.UnitId " +
                "inner join VeichleEntry vc on vc.VeichleId=t.VeichleId " +
                "inner join Supplier su on su.SupplierId=t.SupplierId " +
                "inner join Material mt on mt.MaterialId=t.MaterialId where 1=1");

            if (VehicleId != null)
            {
                sq.Append($" and vc.VeichleId = {VehicleId}");
            }

            if (ticketno != null)
            {
                sq.Append($" and t.TicketNo = {ticketno}");
            }

            if (SupplierId != null)
            {
                sq.Append($" and su.SupplierId = {SupplierId}");
            }

            if (MaterialId != null)
            {
                sq.Append($" and mt.MaterialId = {MaterialId}");
            }
            var rs = db.Query<Transactionvw>(sq);
            return View("Index",rs);
        }
    }
}