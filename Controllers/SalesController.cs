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

            int refConut = 00001;


            var user = User.Identity;
            var a = 0;
            var salesHead = new Sales_Header();

            cusNameArr = form["ItemCustomer"].Split(',');
            cusTypesIdArr = form["CustomerTypeId"].Split(',');
            saleDateArr = form["SaleDate"].Split(',');//UnitId
            itemNamesArr = form["ItemName"].Split(',');
            itemPrcsArr = form["ItemPrice"].Split(',');
            itemQtyArr = form["QtyRqstd"].Split(',');
            unitNameArr = form["ItemUnit"].Split(',');
            unitIdArr = form["UnitId"].Split(',');
            amountPaidArr = form["AmountPaid"].Split(',');

            var sellerName = context.Users.Find(user.GetUserId()).UserName;
            //var buyerName = context.Users.Find(user.GetUserId()).UserName;

            var salesCount = amountPaidArr.Count();
            decimal cashIn = 0;
            for (int i = 0; i < salesCount; i++)
            {
                cashIn += Convert.ToDecimal(amountPaidArr[i]);
            }

           

           // salesHead.Sale_Date = DateTime.Today.Date;
            if (String.IsNullOrWhiteSpace(saleDateArr[0]))
            {
                salesHead.Sale_Date = DateTime.Today.Date;
            }
            else
            {
                salesHead.Sale_Date = Convert.ToDateTime(saleDateArr[0]).Date;
            }
            salesHead.Seller_Id = user.GetUserId();
            salesHead.Seller_Name = sellerName;
            salesHead.Cash_In = cashIn;

            var tmp = cusNameArr[0]; //Single customer Only
            salesHead.CustomerName = tmp;

            var cusTypeId = Convert.ToInt32(cusTypesIdArr[0]);
            var cusTypeName = context.CustomerTypes.Where(x => x.Id == cusTypeId).Select(y => y.Name).First();
            salesHead.CustomerType_Id = cusTypeId;
            salesHead.CustomerType_Name = cusTypeName;
            salesHead.Ref_No = "SRN-"+DateTime.Now.ToShortTimeString()+"-"+DateTime.Now.ToShortDateString();

            a = 1;

            context.Sales_Headers.Add(salesHead);
            context.SaveChanges();

      
            var itemCount = itemNamesArr.Count();

            var saleDetail = new Sales_Detail();
            saleDetail.Cash_In = cashIn;
            
            for (int i = 0; i < itemCount; i++)
            {
                if (String.IsNullOrWhiteSpace(saleDateArr[i]))
                {
                    saleDetail.SaleDate = DateTime.Today.Date;
                }
                else
                {
                    saleDetail.SaleDate = Convert.ToDateTime(saleDateArr[i]).Date;
                }
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

            #region CREDIT SALES

            var creditSales = new CreditSales();
            creditSales.AmountTotal = 0;
            creditSales.Cash_In = cashIn;
            for (int i = 0; i < itemCount; i++)
            {
                creditSales.AmountTotal += Convert.ToDecimal(itemPrcsArr[i]);
            }

            for (int i = 0; i < itemCount; i++)
            {
                //Credit Sales Save
                creditSales.Sales_Header_id = salesHead.Id;
                if (String.IsNullOrWhiteSpace(saleDateArr[i]))
                {
                    creditSales.SaleDate = DateTime.Today;
                }
                else
                {
                    creditSales.SaleDate = Convert.ToDateTime(saleDateArr[i]);
                }
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

               // creditSales.AmountTotal+= Convert.ToDecimal(itemPrcsArr[i]);
            

                var b = 0;
                context.CreditSales.Add(creditSales);
                context.SaveChanges();

            }

            #endregion

            #region STOCK DECREASE
            for (int i = 0; i < itemCount; i++)
            {
                var temp = itemNamesArr[i];
                var currEntry = context.StockWatch
                    .Where(x => x.ItemName == temp )
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                var z = 0;

                if (currEntry != null)
                {
                    var newEntry = new StockWatch();
                    newEntry.ItemId = currEntry.ItemId;
                    newEntry.ItemName = currEntry.ItemName;
                    newEntry.SalesId = salesHead.Id;
                    newEntry.QtyOut = currEntry.QtyIn - decimal.Parse(itemQtyArr[i]);
                    newEntry.SellingPrice = decimal.Parse(itemPrcsArr[i]);
                    newEntry.QtyIn = currEntry.QtyIn;
                    newEntry.QtyBalance = currEntry.QtyIn - newEntry.QtyOut;
                    newEntry.UnitId = currEntry.UnitId;
                    newEntry.UnitName = currEntry.UnitName;
                    newEntry.BuyingPrice = currEntry.BuyingPrice;
                    newEntry.PurchaseId = currEntry.PurchaseId;

                    context.StockWatch.Add(newEntry);
                    context.SaveChanges();
                }
            }
            #endregion

            #region RECEIPT
            var receipt = new Receipt_Head();

            receipt.SalesDetailId = saleDetail.Id;
            receipt.Date = DateTime.Now;
            receipt.CustomerName = saleDetail.CustomerName;
            //saleDetail.
            context.Receipt_Heads.Add(receipt);

            #endregion

            context.SaveChanges();

   
            a = 2; // If u get here then Everything works.

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
            Object data;
            var unitId = Convert.ToInt32(id);
            var itemName_ = item;

            var unitName = context.Units.Find(unitId).Unit_Name;

            var itemId_ = context.Items.Where(x => x.Item_Name == itemName_).Select(x => x.Id);

            var itemAmout = Convert.ToDecimal(context.PriceLists
                .Where(x => x.Unit_Id == unitId && x.Item_Name == itemName_)
                .Select(x => x.PriceValue).First());

           
            data = new { unitName, itemAmout, itemId_ };


            return Json(data, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetUnitName(string id)
        {
            var unitId = Convert.ToInt32(id);

            var unitName = context.Units.Find(unitId).Unit_Name;

            var data = new { unitName };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCreditSaleSingle(string id, string itemName, string newAmount)
        {
            var user = User.Identity;

            var saleHeadId = Convert.ToInt32(id);
            var itemName_ = context.Items.Where(x => x.Item_Name == itemName).First();
            
            var newSaleAmount = Convert.ToDecimal(newAmount);

            var creditSaleEntry = context.CreditSales.Where(x=>x.Item_Name == itemName).First();
            var oldSaleEntry = context.Sales_Details.Where(x => x.ItemName == itemName).First();

            //Sales Header
            var oldHeader = context.Sales_Headers.Find(saleHeadId);


            var salesHeader = new Sales_Header();
            salesHeader.Ref_No = oldHeader.Ref_No;
            salesHeader.Sale_Date = DateTime.Now;
            salesHeader.Seller_Id = user.GetUserId();
            salesHeader.Seller_Name = user.GetUserName();
            salesHeader.CustomerName = oldHeader.CustomerName;
            salesHeader.CustomerType_Id = oldHeader.CustomerType_Id;
            salesHeader.CustomerType_Name = oldHeader.CustomerType_Name;
            salesHeader.Cash_In = newSaleAmount;
            context.Sales_Headers.Add(salesHeader);
            context.SaveChanges();

            //Sales Detail

            #region SALE DETAIL

            var newSaleEntry = new Sales_Detail();
            newSaleEntry.ItemName = oldSaleEntry.ItemName;
            newSaleEntry.Qty = oldSaleEntry.Qty;
            newSaleEntry.SaleDate = DateTime.Now;
            newSaleEntry.UniId = oldSaleEntry.UniId;
            newSaleEntry.Unit_Name = oldSaleEntry.Unit_Name;
            newSaleEntry.CustomerName = oldSaleEntry.CustomerName;
            newSaleEntry.Cash_In = newSaleAmount;
            newSaleEntry.Amount = oldSaleEntry.Amount;
            newSaleEntry.AmountPaid = newSaleAmount;
            newSaleEntry.Sales_Header_id = salesHeader.Id;
            context.Sales_Details.Add(newSaleEntry);
            context.SaveChanges();

            #endregion

            #region CREDIT SALE

            var newcreditSaleEntry = new CreditSales();
            newcreditSaleEntry.Item_Name = creditSaleEntry.Item_Name;
            newcreditSaleEntry.QtySold = creditSaleEntry.QtySold;
            newcreditSaleEntry.SaleDate = DateTime.Now ;
            newcreditSaleEntry.UniId  = creditSaleEntry.UniId;
            newcreditSaleEntry.Unit_Name = creditSaleEntry.Unit_Name;
            newcreditSaleEntry.CusTypeId  = creditSaleEntry.CusTypeId;
            newcreditSaleEntry.CusTypeName = creditSaleEntry.CusTypeName;
            newcreditSaleEntry.Customer_Name = creditSaleEntry.Customer_Name;
            newcreditSaleEntry.Cash_In = newSaleAmount;
            newcreditSaleEntry.AmountCost = creditSaleEntry.AmountCost;
            newcreditSaleEntry.AmountPaid = newSaleAmount;
            newcreditSaleEntry.AmountTotal = creditSaleEntry.AmountTotal;
            newcreditSaleEntry.AmountBalance = creditSaleEntry.AmountBalance - newSaleAmount;
            newcreditSaleEntry.Sales_Header_id  = salesHeader.Id;
            context.CreditSales.Add(newcreditSaleEntry);
            context.SaveChanges();

            #endregion

            var data = new { newcreditSaleEntry };

            return Json(data, JsonRequestBehavior.AllowGet);
        }





    }


}