using AsyncSample.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private DashboardLogic dashboardLogic;

        public HomeController()
        {
            dashboardLogic = new DashboardLogic();
        }

        public async Task<ActionResult> Index()
        {
            var dashboard = await dashboardLogic.GetDashboardData();
            return View(dashboard);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}