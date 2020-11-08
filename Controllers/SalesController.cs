using MEGAPos.Models;
using MEGAPos.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext context;
        private string conn = @"Data Source=.\FRINNOSQLSERVER;Persist Security Info=True;Initial Catalog=MEGAPOS;Integrated Security = true";

        private string dateFormat = "dd/MM/yyyy";
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
            List<SelectListItem> customerTypes = new List<SelectListItem>();
            foreach (var unit in context.CustomerTypes)
            {
                customerTypes.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }

            ViewBag.CusTypes = customerTypes;

            //units
            List<SelectListItem> unitList = new List<SelectListItem>();

            foreach (var item in context.Units)
            {
                unitList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Unit_Name });
            }

            ViewBag.Units = unitList;

            return View();
        }

        [HttpPost]
        public ActionResult NewSale(FormCollection form)
        {
            string[] itemNamesArr, itemPrcsArr, 
                itemQtyArr, itemIdArr, cusTypesIdArr, 
                cusNameArr, cusTypeNameArr, unitIdArr, 
                unitNameArr, saleDateArr, amountPaidArr;


            var user = User.Identity;
            var a = 0;
            var salesHead = new Sales_Header();

            cusNameArr = form["ItemCustomer"].Split(',');
            cusTypesIdArr = form["CustomerTypeId"].Split(',');
            saleDateArr = form["SaleDate"].Split(',');//UnitId

            var sellerName = context.Users.Find(user.GetUserId()).UserName;
            //var buyerName = context.Users.Find(user.GetUserId()).UserName;

           

            salesHead.Sale_Date = Convert.ToDateTime(saleDateArr[0]);
            salesHead.Seller_Id = user.GetUserId();
            salesHead.Seller_Name = sellerName;

            var tmp = cusNameArr[0]; //Single customer Only
            salesHead.CustomerName = tmp;

            var cusTypeId = Convert.ToInt32(cusTypesIdArr[0]);
            var cusTypeName = context.CustomerTypes.Where(x => x.Id == cusTypeId).Select(y => y.Name).First();
            salesHead.CustomerType_Id = cusTypeId;
            salesHead.CustomerType_Name = cusTypeName;



            a = 1;

            context.Sales_Headers.Add(salesHead);
            context.SaveChanges();

      
            //Sale Detail Process
      
            itemNamesArr = form["ItemName"].Split(',');
            itemPrcsArr = form["ItemPrice"].Split(',');
            itemQtyArr = form["QtyRqstd"].Split(',');
            
            unitNameArr = form["ItemUnit"].Split(',');
            unitIdArr = form["UnitId"].Split(',');
            amountPaidArr = form["AmountPaid"].Split(',');


            var itemCount = itemNamesArr.Count();

            var saleDetail = new Sales_Detail();
            var saleDetailList = new List<Sales_Detail>();

   

            for (int i = 0; i < itemCount; i++)
            {
                saleDetail.SaleDate = Convert.ToDateTime(saleDateArr[i]);
                saleDetail.ItemName = itemNamesArr[i];
                saleDetail.Qty = Convert.ToInt32(itemQtyArr[i]);
                saleDetail.Amount = Convert.ToDecimal(itemPrcsArr[i]);
                saleDetail.AmountPaid = Convert.ToDecimal(amountPaidArr[i]);
                saleDetail.Sales_Header_id = salesHead.Id;
                saleDetail.CustomerName = cusNameArr[i];

                saleDetail.UniId = Convert.ToInt32(unitIdArr[i]);
                saleDetail.Unit_Name = unitNameArr[i];
                context.Sales_Details.Add(saleDetail);

                context.SaveChanges();
            }

            var creditSales = new CreditSales();
            var creditSalesList = new List<CreditSales>();
            creditSales.AmountTotal = 0;

            for (int i = 0; i < itemCount; i++)
            {
                //Credit Sales Save
                creditSales.Sales_Header_id = salesHead.Id;
                creditSales.SaleDate = Convert.ToDateTime(saleDateArr[i]);
                creditSales.Item_Name = itemNamesArr[i];
                creditSales.QtySold = Convert.ToInt32(itemQtyArr[i]);
                creditSales.AmountCost = Convert.ToDecimal(itemPrcsArr[i]);
                creditSales.AmountPaid = Convert.ToDecimal(amountPaidArr[i]);
                creditSales.Customer_Name = cusNameArr[i];
                creditSales.CusTypeId = cusTypeId;
                creditSales.CusTypeName = cusTypeName;


                creditSales.UniId = Convert.ToInt32(unitIdArr[i]);
                creditSales.Unit_Name = unitNameArr[i];
                if (creditSales.AmountCost != creditSales.AmountPaid)
                {
                    creditSales.AmountBalance = creditSales.AmountCost - creditSales.AmountPaid;
                }
                else
                {
                    creditSales.AmountBalance = 0;
                }

                creditSales.AmountTotal+= Convert.ToDecimal(itemPrcsArr[i]);
            

                var b = 0;
                context.CreditSales.Add(creditSales);
                context.SaveChanges();

            }

           
     

            #region RECEIPT
            var receipt = new Receipt_Head();

            receipt.SalesDetailId = saleDetail.Id;
            receipt.Date = DateTime.Now;
            receipt.CustomerName = saleDetail.CustomerName;
            //saleDetail.
            context.Receipt_Heads.Add(receipt);

            #endregion

            context.SaveChanges();

   
            a = 2;

            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteSale(int id)
        {
            var saleHead = context.Sales_Headers.Find(id);
            return View(saleHead);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, FormCollection form)
        {
            var saleHead = context.Sales_Headers.Find(id);

            var saleDetail = context.Sales_Details.Where(x => x.Sales_Header_id == saleHead.Id && x.SaleDate == saleHead.Sale_Date).ToList();

            var creditSales = context.CreditSales.Where(x => x.Sales_Header_id == saleHead.Id && x.SaleDate == saleHead.Sale_Date).ToList();



            //remove

            for (int i = 0; i < saleDetail.Count; i++)
            {
                context.Sales_Details.Remove(saleDetail[i]);
                context.SaveChanges();
            }

            for (int i = 0; i < creditSales.Count; i++)
            {
                context.CreditSales.Remove(creditSales[i]);
                context.SaveChanges();
            }

            context.Sales_Headers.Remove(saleHead);
            context.SaveChanges();


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

        public ActionResult SalesManage(int id)
        {
            var creditSales = context.CreditSales.Where(x=>x.Sales_Header_id == id).ToList();

            return View(creditSales);
        }

        public JsonResult GetSalePrice(string id, string item)
        {
            var unitId = Convert.ToInt32(id);
            var itemName_ = item;

            var unitName = context.Units.Find(unitId).Unit_Name;

            var itemAmout = Convert.ToDecimal(context.PriceLists
                .Where(x => x.Unit_Id == unitId && x.Item_Name == itemName_)
                .Select(x => x.PriceValue).First());

            var data = new { unitName, itemAmout };


            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateCreditSale(FormCollection form)
        {

            return Json("", JsonRequestBehavior.AllowGet);
        }





    }


}