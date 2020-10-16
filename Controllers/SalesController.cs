using MEGAPos.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext context;
        private string conn = @"Data Source=.\FRINNOSQLSERVER;Persist Security Info=True;Initial Catalog=MEGAPOS;Integrated Security = true";

        public SalesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }   

        //Get Sales Cart
        public ActionResult NewSale()
        {
            var seller = User.Identity;
            var items = context.Items.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult NewSale(FormCollection form)
        {


            var user = User.Identity;
            var a = 0;
            var salesHead = new Sales_Header();

            salesHead.Sale_Date = DateTime.Now;
            salesHead.Seller_Id = user.GetUserId();

            context.Sales_Headers.Add(salesHead);
            context.SaveChanges();

            a = 1;

            //Sale Detail Process
            var itemCount = form["ItemName"].Count();
            var saleDetail = new Sales_Detail();
            var saleDetailList = new List<Sales_Detail>();

            for (int i = 0; i < itemCount; i++)
            {
                saleDetail.ItemName = form["ItemName"];
            }


            return RedirectToAction("Index", "Users");
        }


    }


}