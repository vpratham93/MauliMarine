using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;
using PagedList;

namespace MauliMarineRes
{
    public class Materialvw
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string Quantity { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
    }

    public class Transactionvw
    {
        public int TicketNo { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int VeichleId { get; set; }
        public string VeichleNumber { get; set; }
        public decimal LoadedWeight { get; set; }
        public decimal EmptyWeight { get; set; }
        public decimal NetWeight { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public decimal RecievedAmt { get; set; }
        public TimeSpan Ttime { get; set; }
        public DateTime Tdate { get; set; }
    }
}