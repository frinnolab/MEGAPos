using MEGAPos.Models;
using MEGAPos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
       
        ApplicationDbContext db = new ApplicationDbContext();

      
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        #region
        //SaleTypes
        public ActionResult CreateSaleType()
        {
            var saleTypeList = db.SalesTypes.ToList();
            var settinngsVM = new SettingsViewModel()
            {
                SalesTypes = saleTypeList
            };
            return View();
        }

        public ActionResult SaleTypeIndex()
        {
            var saleList = db.SalesTypes.ToList();
            var settings = new SettingsViewModel()
            {
                SalesTypes = saleList
            };
            return View(settings);
        }

        [HttpPost]
        public ActionResult CreateSaleType(FormCollection form)
        {
            var saleType = new SalesType();

            saleType.SaleName = form["SaleName"];

            db.SalesTypes.Add(saleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");

        }

        public ActionResult EditSaleType(int id)
        {
            var SaleType = db.SalesTypes.Find(id);

            return View(SaleType);
        }

        [HttpPost]
        public ActionResult EditSaleType(int id, FormCollection  form)
        {
            var SaleType = db.SalesTypes.Find(id);

            SaleType.SaleName = form["SaleName"];

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteSaleType(int id)
        {
            var saleType = db.SalesTypes.Find(id);

            return View(saleType);
        }

        [HttpPost]
        public ActionResult DeleteSaleType(int id, FormCollection form)
        {
            var SaleType = db.SalesTypes.Find(id);

            db.SalesTypes.Remove(SaleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region PRICE TYPES/LIST
        public ActionResult ItemPrices()
        {
            decimal wholeSalePrice, retailPrice;
            var itemPrices = db.PriceLists.ToList();

            var wholesaleItemPriceList = db.PriceLists.Where(x => x.PriceType_Id == 1).ToList();

            var retailItemPriceList = db.PriceLists.Where(x => x.PriceType_Id == 2).ToList();
            var item_ = new Item();

            foreach (var item in wholesaleItemPriceList)
            {

            }



            return View("ItemPrices");
            
        }
        public ActionResult PriceListIndex()
        {
            db = new ApplicationDbContext();
            var unitlist = new List<SelectListItem>();
            foreach (var unit in db.SalesTypes)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.SaleName });
            }

            ViewBag.Units = unitlist;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePriceList(FormCollection form)
        {
            string[] itemNamesArr, itemPrcsArr, itemPrcTypArr, itemIdArr, cusIdArr, cusNameArr;

            itemNamesArr = form["ItemName"].Split(',');
            itemPrcTypArr = form["PriceTypeId"].Split(','); 
            itemPrcsArr = form["ItemPrice"].Split(',');
            itemIdArr = form["ItemId"].Split(',');

            var itemCount = itemNamesArr.Count();

            var priceList = new PriceList();
            var priceLists = new List<PriceList>();

            for (int i = 0; i < itemCount; i++)
            {
                priceList.Item_Id = Convert.ToInt32(itemIdArr[i]);
                priceList.PriceType_Id = Convert.ToInt32(itemPrcTypArr[i]);
                priceList.PriceValue = Convert.ToDecimal(itemPrcsArr[i]);
                db.PriceLists.Add(priceList);
                db.SaveChanges();
            }



            var a = 2;


            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region VAT
        public ActionResult VATIndex()
        {
            var vatList = db.VATs.ToList();

            var vm = new VATViewModel()
            {
                vATs = vatList
            };

            return View(vm);
        }

        public ActionResult CreateVAT()
        {
            var vats = db.VATs.ToList();
            var vm = new VATViewModel()
            {
                vATs = vats
            };
            return View();
        }

        [HttpPost]
        public ActionResult CreateVAT(FormCollection form)
        {
            var vat = new VAT();
            vat.Name = form["Name"];
            vat.Value = Convert.ToDecimal( form["Value"]);

            db.VATs.Add(vat);
            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult EditVAT(int id)
        {
            var vat = db.VATs.Find(id);

            return View(vat);
        }

        [HttpPost]
        public ActionResult EditVAT(int id, FormCollection form)
        {
            var vat = db.VATs.Find(id);
            vat.Name = form["Name"];
            vat.Value = Convert.ToDecimal(form["Value"]);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region VENDORS
        public ActionResult VendorIndex()
        {
            var vendrTypes = db.VendorTypes.ToList();

            var vendorVM = new VendorViewModel()
            {
                VendorTypes = vendrTypes
            };

            return View(vendorVM);
        }

        public ActionResult CreateVendorType()
        {
            //Vendor Type Form

            return View();
        }

        [HttpPost]
        public ActionResult CreateVendorType(FormCollection form)
        {
            var vendorType = new VendorType();

            if (ModelState.IsValid)
            {
                vendorType.Name = form["Name"];
                db.VendorTypes.Add(vendorType);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Users");
        }

        public ActionResult EditVendorType(int id)
        {
            var venType = db.VendorTypes.Find(id);

            return View(venType);
        }

        [HttpPost]
        public ActionResult EditVendorType(int id, FormCollection form)
        {
            var venType = db.VendorTypes.Find(id);

            venType.Name = form["Name"];
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteVendorType(int id)
        {
            var venType = db.VendorTypes.Find(id);
            return View(venType);
        }

        [HttpPost]
        public ActionResult DeleteVendorType(int id, FormCollection form)
        {
            var venType = db.VendorTypes.Find(id);

            db.VendorTypes.Remove(venType);
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region CUSTOMERS
        public ActionResult CustomerIndex()
        {
            var vendrTypes = db.CustomerTypes.ToList();

            var vendorVM = new VendorViewModel()
            {
                CustomerTypes = vendrTypes
            };

            return View(vendorVM);
        }

        public ActionResult CreateCustomerType()
        {
            //Vendor Type Form

            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomerType(FormCollection form)
        {
            var customerType = new CustomerType();

            if (ModelState.IsValid)
            {
                customerType.Name = form["Name"];
                db.CustomerTypes.Add(customerType);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Users");
        }

        public ActionResult EditCustomerType(int id)
        {
            var cusType = db.CustomerTypes.Find(id);

            return View(cusType);
        }

        [HttpPost]
        public ActionResult EditCustomerType(int id, FormCollection form)
        {
            var cusType = db.CustomerTypes.Find(id);

            cusType.Name = form["Name"];
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteCustomerType(int id)
        {
            var cusType = db.CustomerTypes.Find(id);
            return View(cusType);
        }

        [HttpPost]
        public ActionResult DeleteCustomerType(int id, FormCollection form)
        {
            var cusType = db.CustomerTypes.Find(id);

            db.CustomerTypes.Remove(cusType);
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region DISTRIBUTORS
        public ActionResult DitributorIndex()
        {

            return View();
        }
        #endregion

    }
}