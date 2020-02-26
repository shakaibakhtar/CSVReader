using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSVReader.Controllers
{
    public class FileHandlingController : Controller
    {
        // GET: FileHandling
        public ActionResult ExportToTxt()
        {
            return View();
        }
    }
}