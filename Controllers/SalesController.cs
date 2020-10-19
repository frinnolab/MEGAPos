using MEGAPos.Models;
using MEGAPos.ViewModels;
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


            var sellerName = context.Users.Find(user.GetUserId()).UserName;
            var buyerName = context.Users.Find(user.GetUserId()).UserName;

            salesHead.Sale_Date = DateTime.Now;
            salesHead.Seller_Id = user.GetUserId();
            salesHead.Seller_Name = sellerName;
            salesHead.Buyer_Name = buyerName;


            context.Sales_Headers.Add(salesHead);
            context.SaveChanges();

            a = 1;

            //Sale Detail Process

            string[] itemNamesArr, itemPrcsArr, itemQtyArr, itemIdArr;
            itemNamesArr = form["ItemName"].Split(',');
            itemPrcsArr = form["ItemPrice"].Split(',');
            itemQtyArr = form["QtyRqstd"].Split(',');
            itemIdArr = form["ItemId"].Split(',');
            var itemCount = itemNamesArr.Count();

            var saleDetail = new Sales_Detail();
            var saleDetailList = new List<Sales_Detail>();


            for (int i = 0; i < itemCount; i++)
            {
                saleDetail.ItemName = itemNamesArr[i];
                saleDetail.Qty = Convert.ToInt32(itemQtyArr[i]);
                saleDetail.Price = Convert.ToDecimal(itemPrcsArr[i]);
                saleDetail.Sales_Header_id = salesHead.Id;
                saleDetail.Item_id = Convert.ToInt32(itemIdArr[i]);
                context.Sales_Details.Add(saleDetail);
                context.SaveChanges();
            }

            

            a = 2;

            
            


            return RedirectToAction("Index", "Users");
        }

        public ActionResult SalesDetail(int id)
        {
            var a = 0;
            var saleHead = context.Sales_Headers.Find(id);

            var saleDetails = context.Sales_Details.Where(m => m.Sales_Header_id == saleHead.Id).ToList();

            var salesVm = new SalesViewModel()
            {
                sales_Header = saleHead,
                sales_Details = saleDetails
            };
            return View(salesVm);
        }


    }


}