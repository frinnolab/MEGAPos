using MEGAPos.Reports;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MEGAPos.Controllers
{
    public class ReportsController : Controller
    {
        
        private ReportDataSet ds;
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }


        //
        public ActionResult SalesReport()
        {
            ds = new ReportDataSet();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);

            var connectionString = ConfigurationManager.ConnectionStrings["FrinnoConnect"].ConnectionString;

            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Sales_Detail", conx);

            adp.Fill(ds, ds.Sales_Detail.TableName);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Report1.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", ds.Tables[0]));

            ViewBag.SalesReport = reportViewer;

            return View();
        }
    }
}