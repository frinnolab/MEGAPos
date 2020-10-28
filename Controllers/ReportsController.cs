using MEGAPos.Models;
using MEGAPos.Reports;
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
        // GET: Reports

        public ActionResult ReportsIndex()
        {
            return View();
        }
        public ActionResult Index()
        {
            context = new ApplicationDbContext();
            var unitlist = new List<SelectListItem>();
            foreach (var unit in context.Units)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Unit_Name });
            }

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
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Sales_Detail", conx);

            adp.Fill(ds, ds.Sales_Detail.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Sales\SalesReport.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataSet", ds.Tables[0]));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("SalesDataset", ds.Tables[1]));

            ViewBag.SalesReport = reportViewer;

            return View();
        }
    }
}