using MEGAPos.Models;
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
            var items = context.Items.ToList();

            return View();
        }

        public JsonResult GetItemName(string getItemname)
        {
            var item = context.Items.Where(m=>m.Qty_In );
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    SqlCommand select = new SqlCommand("SELECT [Item_Name],[Qty_In] FROM [MEGAPOS].[dbo].[Items] WHERE [Item_Name]  LIKE '%" + getItemname + "%'");
                    //SqlCommand select = new SqlCommand("SELECT [ItemNumber],[ItemName] FROM [DummyDB].[dbo].[Medicines] WHERE [ItemNumber]  LIKE '%" + itemNumber + "%' AND [ItemName]  LIKE '%" + itemName + "%'");
                    select.Connection = connection;


                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.Read())
                    {
                        var singleNote = new Medicines();

                        singleNote.ItemName = reader["ItemName"].ToString();
                        singleNote.ItemNumber = Convert.ToInt32(reader["ItemNumber"]);
                        noteDetailList.Add(singleNote);
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
    }


}