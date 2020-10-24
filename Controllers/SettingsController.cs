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
            var item_ = new Item();


            foreach (var item in itemPrices)
            {
                
                item_.Item_Name = db.Items.Find(item.Item_Id).Item_Name;

                //wholeSalePrice = db.PriceLists.Where(m => m.Item_Id == item_.Id).Select(x => x.PriceType_Id == 1);
                var priceTypeId = db.PriceLists.Where(m => m.Item_Id == item_.Id).Select(y => y.PriceType_Id).ToList();

          
                var tmpWhsPrc = db.PriceLists.Where(x => x.PriceType_Id == priceTypeId[0]).Select(x => x.PriceValue).ToString();
                var tmpRtrPrc = db.PriceLists.Where(x => x.PriceType_Id == priceTypeId[1]).Select(x => x.PriceValue).ToString();
                wholeSalePrice = Convert.ToDecimal(tmpWhsPrc);
                retailPrice = Convert.ToDecimal(tmpRtrPrc);

                var priceListVm = new PriceListViewModel()
                {
                    ItemName = item_.Item_Name,
                    Item_id = item_.Id,
                    WholeSalePrice = wholeSalePrice,
                    RetailPrice = retailPrice
                };

                return View(priceListVm);
            }

            return RedirectToAction("Index", "Users");
            
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

            return View();
        }

        public ActionResult CreateVendorType()
        {
            //Vendor Type Form

            return View();
        }
        #endregion
    }
}