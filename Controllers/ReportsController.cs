using MEGAPos.Models;
using MEGAPos.Reports;
using MEGAPos.Reports.Purchases;
using MEGAPos.Reports.Sales;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MEGAPos.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext context;
        public ReportsController()
        {
            context = new ApplicationDbContext();
        }
        private SalesDataSet ds;

        private PurchaseDataSet pds;
        // GET: Reports

        public ActionResult ReportsIndex()
        {
            return View();
        }

        #region SALES REPORT
        public ActionResult Index()
        {
            context = new ApplicationDbContext();
            var unitlist = new List<SelectListItem>();
            foreach (var unit in context.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

            //Store Locations
            List<SelectListItem> locList = new List<SelectListItem>();

            foreach (var item in context.StoreLocations)
            {
                locList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.StoreName });
            }

            ViewBag.locations = locList;

            ViewBag.Units = unitlist;

            return View();
        }
        //
        public ActionResult SalesReport()
        {
            ds = new SalesDataSet();
            ReportViewer reportViewer = new ReportViewer();                                                                                                                                                                                                                                     
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM CreditSales", conx);

            adp.Fill(ds, ds.CreditSales.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Sales\SalesReport.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataSet1", ds.Tables[0]));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataset", ds.Tables[1]));

            ViewBag.SalesReport = reportViewer;

            return View();
        }

        public ActionResult SalesReportFilter(string fromDate, string toDate, string itemName, string customer, string Location)
        {
            //      int SaleHeader = int.Parse(id);

            ds = new SalesDataSet();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp;
            //Any
            if (!string.IsNullOrEmpty(fromDate)|| !string.IsNullOrEmpty(toDate)  || !string.IsNullOrEmpty(itemName) || !string.IsNullOrWhiteSpace(customer))//Any
            {

                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(customer))   //All
                {
                    adp = new SqlDataAdapter("SELECT * FROM CreditSales where SaleDate BETWEEN '"
                        + fromDate +"'"+" AND '" + toDate+"'" +
                        " AND  Item_Name = '" + itemName +"'", conx);

                    adp.Fill(ds, ds.CreditSales.TableName);
                }
                else
                {
                    adp = new SqlDataAdapter("SELECT * FROM CreditSales where SaleDate BETWEEN '"
                    + fromDate + "'" +
                    " AND '" + toDate + "'"
                    +
                    " AND  Item_Name = '" + itemName + "'", conx);


                    adp.Fill(ds, ds.CreditSales.TableName);
                }

                
            }
            else //Non
            {
                adp = new SqlDataAdapter("SELECT * FROM CreditSales", conx);
                adp.Fill(ds, ds.CreditSales.TableName);
            }


            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Sales\SalesReport.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataSet1", ds.Tables[0]));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesHeadDataset", ds.Tables[0]));

            ViewBag.SalesReport = reportViewer;

            return View("SalesReport");
        }

        public ActionResult DailySales(int id)
        {
            var saleHeader = id;

            

            return View();
        }

        public ActionResult SalesReceipt(int id)
        {
            var saleHeadId = id;
            //var saleHeader = context.Sales_Headers.Where(x => x.Id == saleHeadId);

            //var salesDetail = context.CreditSales.Where(x => x.Sales_Header_id == saleHeadId).ToList();

            ds = new SalesDataSet();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM CreditSales where Sales_Header_id = '"
                        + saleHeadId + "'", conx);

            adp.Fill(ds, ds.CreditSales.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Sales\SalesReceipts.rdlc";

            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataSet1", ds.Tables[0]));




            return View();
        }

        #endregion

        #region PURCHASES REPORT
        public ActionResult PurchaseIndex()
        {
            return View();
        }

        #region Delete Here
        //public ActionResult PurchaseReport()
        //{
        //    pds = new PurchaseDataSet();
        //    ReportViewer reportViewer = new ReportViewer();
        //    reportViewer.ProcessingMode = ProcessingMode.Local;
        //    reportViewer.SizeToReportContent = true;
        //    reportViewer.Width = Unit.Percentage(900);
        //    reportViewer.Height = Unit.Percentage(900);

        //    var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

        //    SqlConnection conx = new SqlConnection(connectionString);
        //    SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Purchase_Detail", conx);

        //    adp.Fill(pds, pds.Purchase_Detail.TableName);

        //    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Purchases\PurchaseReport.rdlc";

        //    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("PurchaseDataSet0", pds.Tables[0]));
            

        //    ViewBag.PurchasesReport = reportViewer;

        //    return View();
        //}
        #endregion

        public ActionResult PurchaseReport(string fromDate, string toDate, string itemName, string vendor)
        {

            pds = new PurchaseDataSet();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp;
            //Any
            if (!string.IsNullOrEmpty(fromDate) || !string.IsNullOrEmpty(toDate) || !string.IsNullOrEmpty(itemName) || !string.IsNullOrWhiteSpace(vendor))
            {

                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(vendor))   //All
                {
                    adp = new SqlDataAdapter("SELECT * FROM Purchase_Detail where PurchaseDate BETWEEN '"
                        + fromDate + "'" + " AND '" + toDate + "'" +
                        " AND  Item_Name = '" + itemName + "'" +
                        " AND  Vendor_Name = '" + vendor + "'", conx);

                    adp.Fill(pds, pds.Purchase_Detail.TableName);
                }

                adp = new SqlDataAdapter("SELECT * FROM Purchase_Detail where PurchaseDate BETWEEN '"
                    + fromDate + "'" +
                    " AND '" + toDate + "'"
                    +
                    " OR  Item_Name = '" + itemName + "'"
                    +
                    " OR  Vendor_Name = '" + vendor + "'", conx);


                adp.Fill(pds, pds.Purchase_Detail.TableName);
            }
            else //Non
            {
                adp = new SqlDataAdapter("SELECT * FROM Purchase_Detail", conx);
                adp.Fill(pds, pds.Purchase_Detail.TableName);
            }


            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Purchases\PurchaseReport.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("PurchaseDataSet0", pds.Tables[0]));


            ViewBag.PurchasesReport = reportViewer;


         

            return View("PurchaseReport");
        }
        #endregion
    }
}