using MEGAPos.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Models
{
    [Authorize]
    public class InventoryController : Controller
    {
        private ApplicationDbContext context;
        private string conn = @"Data Source=.\FRINNOSQLSERVER;Persist Security Info=True;Initial Catalog=MEGAPOS;Integrated Security = true";

        public InventoryController()
        {
            context = new ApplicationDbContext();
        }

        //PURCHASE
        public ActionResult NewPurchase()
        {
            //var purchaseDetail = new Purchase_Detail();
            
            return View();
        }
        //PURCHASE END
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create new Item
        public ActionResult Create()
        {
            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in context.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

            List<SelectListItem> vatlist = new List<SelectListItem>();
            foreach (var unit in context.VATs)
            {
                vatlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }


            ViewBag.Units = unitlist;

            ViewBag.Vats = vatlist;

            return View();
        }

        #region VENDOR 
        public ActionResult VendorItemCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewVendorItem(FormCollection form)
        {
            var itemIdsArr = form[""].Split(',');
            return RedirectToAction("Index", "Users");
        }
        #endregion

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var user = User.Identity;

            var items = new Item();

            

            var unitId = Convert.ToInt32(collection["Unit_Id"]);
            var vatId = Convert.ToInt32(collection["Is_VAT_Id"]);

            var unitName = context.Units.Find(unitId).Unit_Name;
            var vatValue = context.VATs.Find(vatId).Value;

            if (ModelState.IsValid)
            {
                items.ItemDateCreated = DateTime.Now;
                items.Item_Name = collection["Item_Name"];
                //items.ItemDateUpdate = DateTime.Now;
                items.DummyPrice= Convert.ToDecimal(collection["DummyPrice"]) ;
                items.Description = collection["Description"];
                items.Created_By = user.GetUserId();
                items.Unit_Id =unitId;
                items.Unit_Name = unitName;
                items.Is_VAT_Id = vatId;
                items.VatValue = vatValue;
                context.Items.Add(items);
                context.SaveChanges();
               
            }
            return RedirectToAction("Index", "Users");

        }

        //GET Units Of Measure
        public ActionResult CreateUnit()
        {
            
            return View();
        }

        //Post UOM
        [HttpPost]
        public ActionResult CreateUnit(FormCollection form)
        {

            var items = new U_O_M();

            if (ModelState.IsValid)
            {
                items.Unit_Name = form["Unit_Name"];
                
                context.Units.Add(items);
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Users");
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var item = context.Items.Find(id);
            return View(item);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var user = User.Identity;
            var items = new Item();
            if (ModelState.IsValid)
            {
                items.ItemDateCreated = DateTime.Now;
                //items.Item_Name = collection["Item_Name"];
                items.ItemDateUpdate = DateTime.Now;
                items.Qty_In = Convert.ToDecimal(collection["Qty_In"]);
                items.Description = collection["Description"];
                items.Created_By = user.GetUserId();
                context.Items.Add(items);
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Users");
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetSingleItem(string getItemname)
        {
            var data = new DataTable();

            var ItemList = new List<Item>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT [Item_Name], FROM [MEGAPOS].[dbo].[Items] WHERE [Item_Name]  LIKE '%" + getItemname + "%'");
                    //SqlCommand select = new SqlCommand("SELECT [ItemNumber],[ItemName] FROM [DummyDB].[dbo].[Medicines] WHERE [ItemNumber]  LIKE '%" + itemNumber + "%' AND [ItemName]  LIKE '%" + itemName + "%'");
                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        var singleItem = new Item();

                        singleItem.Item_Name = reader["Item_Name"].ToString();

                        ItemList.Add(singleItem);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                connection.Close();

            }

            var item = ItemList.Select(x => new
            {
                label = x.Item_Name,
            });

            return Json(item.Take(10), JsonRequestBehavior.AllowGet);
        }

        //MANAGE ITEMS

        public ActionResult EditItem(int id)
        {
            var item = context.Items.Find(id);

            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in context.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

            List<SelectListItem> vatlist = new List<SelectListItem>();
            foreach (var unit in context.VATs)
            {
                vatlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }

            ViewBag.Units = unitlist;

            ViewBag.Vats = vatlist;
            var a = 0;
            return View(item);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult EditItem(int id, FormCollection collection)
        {

            var items = context.Items.Find(id);
            try
            {
                // TODO: Add update logic here

                var user = User.Identity;


                var unitId = Convert.ToInt32(collection["Unit_Id"]);
                var vatId = Convert.ToInt32(collection["Is_VAT_Id"]);

                var unitName = context.Units.Find(unitId).Unit_Name;
                var vatValue = context.VATs.Find(vatId).Value;

                if (ModelState.IsValid)
                {
                    items.ItemDateUpdate = DateTime.Now;
                    items.Item_Name = collection["Item_Name"];
                    //items.ItemDateUpdate = DateTime.Now;
                    items.DummyPrice = Convert.ToDecimal(collection["DummyPrice"]);
                    items.Description = collection["Description"];
                    items.Created_By = user.GetUserId();
                    items.Unit_Id = unitId;
                    items.Unit_Name = unitName;
                    items.Is_VAT_Id = vatId;
                    items.VatValue = vatValue;

                    context.SaveChanges();

                }
                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult DeleteItem(int id)
        {
            var role = context.Items.Find(id);
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult DeleteItem(int id, FormCollection collection)
        {
            var role = context.Items.Find(id);
            try
            {
                context.Items.Remove(role);
                context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }

        //MANAGE UNIT

        public ActionResult EditUnit(int id)
        {
            var item = context.Units.Find(id);

            return View(item);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult EditUnit(int id, FormCollection collection)
        {

            var items = context.Units.Find(id);
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                   
                    items.Unit_Name = collection["Unit_Name"];
                    
                    context.SaveChanges();

                }
                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult DeleteUnit(int id)
        {
            var role = context.Units.Find(id);
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult DeleteUnit(int id, FormCollection collection)
        {
            var role = context.Units.Find(id);
            try
            {
                context.Units.Remove(role);
                context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }


        //STOCK TAKINGS
        public ActionResult NewStockTake()
        {

            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in context.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }


            ViewBag.Units = unitlist;

  
            return View();
        }


        public JsonResult GetItemName(string getItemName)
        {
            var itemList = new List<Item>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT [Item_Name], [DummyPrice] FROM [MEGAPOS].[dbo].[Items] WHERE [Item_Name]  LIKE '%" + getItemName + "%'");
                   
                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        var singleItem = new Item();

                        singleItem.Item_Name = reader["Item_Name"].ToString();
                        singleItem.DummyPrice = Convert.ToDecimal( reader["DummyPrice"]);

                        itemList.Add(singleItem);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                connection.Close();

            }

            var item = itemList.Select(x => new
            {
                label = x.Item_Name,
                value = x.Item_Name
            });

            var a = 0;

            return Json(item.Take(3), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemDetails(string getItemName)
        {
            var item = new Item();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT * FROM [MEGAPOS].[dbo].[Items] WHERE [Item_Name] = '" + getItemName + "'");

                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        item.Item_Name = reader["Item_Name"].ToString();     
                        item.DummyPrice = Convert.ToDecimal(reader["DummyPrice"]);
                        item.Id = Convert.ToInt32(reader["Id"]);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                connection.Close();

            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomer(string getCustomer)
        {
            var customerList = new List<Customers>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT [Customer_Name] FROM [MEGAPOS].[dbo].[Customers] WHERE [Customer_Name]  LIKE '%" + getCustomer + "%'");

                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        var singleCustomer = new Customers();

                        singleCustomer.Customer_Name = reader["Customer_Name"].ToString();

                        customerList.Add(singleCustomer);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                connection.Close();

            }

            var customer = customerList.Select(x => new
            {
                label = x.Customer_Name,
                value = x.Customer_Name
            });

            var a = 0;

            return Json(customer.Take(3), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerDetails(string getCustomer)
        {
            var customer = new Customers();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT * FROM [MEGAPOS].[dbo].[Customers] WHERE [Customer_Name] = '" + getCustomer + "'");

                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        customer.Customer_Name = reader["Customer_Name"].ToString();
                        
                        customer.id = Convert.ToInt32(reader["id"]);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                connection.Close();

            }

            return Json(customer, JsonRequestBehavior.AllowGet);
        }


    }
}
