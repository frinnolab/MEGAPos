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
            var saleTypeList = db.PriceTypes.ToList();

            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in db.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

            ViewBag.Unitypes = unitlist;

            var settinngsVM = new SettingsViewModel()
            {
                PriceTypes = saleTypeList
            };
            return View();
        }

        public ActionResult SaleTypeIndex()
        {
           
            var saleList = db.PriceTypes.ToList();
            var settings = new SettingsViewModel()
            {
                PriceTypes = saleList
            };
            return View(settings);
        }

        [HttpPost]
        public ActionResult CreateSaleType(FormCollection form)
        {
            var saleType = new PriceType();

            var unitId = Convert.ToInt32(form["Unit_Id"]);
            var unitName = db.Units.Where(x => x.Id == unitId).Select(x => x.Unit_Name).First();

            saleType.Name = form["Name"];
            saleType.Unit_Id = unitId;
            saleType.Unit_Name = unitName;
            saleType.ItemCount = Convert.ToInt32(form["ItemCount"]);

            db.PriceTypes.Add(saleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");

        }

        public ActionResult EditSaleType(int id)
        {
            var SaleType = db.PriceTypes.Find(id);
            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in db.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

            ViewBag.Unitypes = unitlist;


            return View(SaleType);
        }

        [HttpPost]
        public ActionResult EditSaleType(int id, FormCollection  form)
        {
            var saleType = db.PriceTypes.Find(id);

            var unitId = Convert.ToInt32(form["Unit_Id"]);
            var unitName = db.Units.Where(x => x.Id == unitId).Select(x => x.Unit_Name).First();



            saleType.Name = form["Name"];
            saleType.Unit_Id = unitId;
            saleType.Unit_Name = unitName;
            saleType.ItemCount = Convert.ToInt32(form["ItemCount"]);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteSaleType(int id)
        {
            var saleType = db.PriceTypes.Find(id);

            return View(saleType);
        }

        [HttpPost]
        public ActionResult DeleteSaleType(int id, FormCollection form)
        {
            var SaleType = db.PriceTypes.Find(id);

            db.PriceTypes.Remove(SaleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region PRICE TYPES/LIST
        public ActionResult ItemPrices()
        {
            var unitlist = new List<SelectListItem>();
            foreach (var unit in db.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }
            ViewBag.Units = unitlist;

            var priceTypelist = new List<SelectListItem>();
            foreach (var unit in db.PriceTypes)
            {
                priceTypelist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }
            ViewBag.priceTypelist = priceTypelist;

            return View("ItemPrices");
            
        }
        public ActionResult PriceListIndex()
        {
            var unitlist = new List<SelectListItem>();
            foreach (var unit in db.PriceTypes)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }

            ViewBag.Units = unitlist;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePriceList(FormCollection form)
        {
            string[] itemNamesArr, itemPrcsArr, itemPrcTypArr, itemIdArr, unitNameArr, itemCountsArr, amountCostArr, prcTypNameArr, unitIdArr;

            itemNamesArr = form["ItemName"].Split(',');
            itemPrcTypArr = form["PriceTypeId"].Split(','); 
            //itemIdArr = form["ItemId"].Split(','); 
            unitNameArr = form["UnitName"].Split(',');
            unitIdArr = form["UnitId"].Split(',');
            itemCountsArr = form["ItemCount"].Split(',');
            amountCostArr = form["AmountCost"].Split(',');//
            prcTypNameArr = form["PriceTypeName"].Split(',');//PriceTypeName




            var itemCount = itemNamesArr.Count();

            var priceList = new PriceList();
            var priceLists = new List<PriceList>();

            for (int i = 0; i < itemCount; i++)
            {
                //priceList.Item_Id = Convert.ToInt32(itemIdArr[i]);
                priceList.Item_Name = itemNamesArr[i];
                priceList.Unit_Name = unitNameArr[i];
                priceList.Unit_Id = Convert.ToInt32( unitIdArr[i]);
                priceList.PriceType_Id = Convert.ToInt32(itemPrcTypArr[i]);
                priceList.PriceType_Name = prcTypNameArr[i];
                priceList.PriceValue = Convert.ToDecimal(amountCostArr[i]);
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

        #region CUSTOMER TYPES
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

        #region DISTRIBUTOR TYPES
        public ActionResult DitributorIndex()
        {
            var distributors = db.Distributors.ToList();
            var distributorTypes = db.DistributorTypes.ToList();

            var settingsVM = new SettingsViewModel()
            {
                Distributors = distributors,
                DistributorTypes = distributorTypes
            };
            return View(settingsVM);
        }

        public ActionResult CreateDistributorType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDistributorType(FormCollection form)
        {
            var distributorType = new DistributorType();

            if (ModelState.IsValid)
            {
                distributorType.Name = form["Name"];
                db.DistributorTypes.Add(distributorType);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Users");
        }

        public ActionResult EditDistributorType(int id)
        {
            var distroType = db.DistributorTypes.Find(id);

            return View(distroType);
        }

        [HttpPost]
        public ActionResult EditDistributorType(int id, FormCollection form)
        {
            var distroType = db.DistributorTypes.Find(id);

            distroType.Name = form["Name"];
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteDistributorType(int id)
        {
            var distroType = db.DistributorTypes.Find(id);
            return View(distroType);
        }

        [HttpPost]
        public ActionResult DeleteDistributorType(int id, FormCollection form)
        {
            var distroype = db.DistributorTypes.Find(id);

            db.DistributorTypes.Remove(distroype);
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region SETTINGS AJAX CALLS
        public JsonResult GetUnitName(string id)
        {
            var prTypeNameId = Convert.ToInt32(id);

            var unitName = db.PriceTypes.Find(prTypeNameId).Unit_Name;

            return Json(unitName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPriceTypeName(string id)
        {
            var prTypeNameId = Convert.ToInt32(id);

            var prTypeName = db.PriceTypes.Find(prTypeNameId).Name;

            return Json(prTypeName, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}