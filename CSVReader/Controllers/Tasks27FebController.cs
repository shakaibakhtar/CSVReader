using CSVReader.Models;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSVReader.Controllers
{
    public class Tasks27FebController : Controller
    {
        /*
         1- Moving car on Banner
         2- Show loader while website is loading
         3- Show gradient on header nav li active
         4- Show gallery with open image in modal on click with nextand previous buttons
         5- Create a button on click create ad download sa zip of any folder on server (Install dotnetzip first: Install-Package DotNetZip -Version 1.13.6)
         */

        // GET: Tasks27Feb
        public ActionResult Index()
        {
            return View();
        }


        // Install dotnetzip before using this zip & download function,,, package manager console command mentioned above
        public ActionResult Download()
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(Server.MapPath("~/Uploads"));

                MemoryStream output = new MemoryStream();
                zip.Save(output);
                return File(output.ToArray(), "application/zip", "download.zip");
            }
        }
    }
}