using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSVReader.Controllers
{
    public class ExportCVController : Controller
    {
        // GET: ExportCV
        public ActionResult ToDoc()
        {
            return View();
        }

        public ActionResult ToPdf()
        {
            return View();
        }

        public ActionResult ToPdfWithStyles()
        {
            // Before exporting to pdf with styles, type this command in package manager console 'Install-Package Rotativa -Version 1.7.4-rc'
            return new PartialViewAsPdf("_CV", null)
            {
                FileName = "CV.pdf"
            };
        }
    }
}