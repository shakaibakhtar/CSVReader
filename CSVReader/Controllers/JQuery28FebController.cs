using CSVReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSVReader.Controllers
{
    public class JQuery28FebController : Controller
    {
        AgentsRecordsEntities db = new AgentsRecordsEntities();

        // GET: JQuery28Feb

        /*
         Tasks for 28th Feb, 2020

        1- Jquery Rich Textbox (jqueryte plugin)
        2- Modify DOM (Change button color etc)
        3- Validations (If textbox is empty change it's border color and bg to red)
        4- Contact us form submit with validations
        5- Populate select option with jquery ajax
        6- Append to DOM, InsertAfter, InsertBefore, Before
        7- External JS
        8- Add table in DOM using JQuery
        9- ProgressBar Jquery
        10- CRUD in Table using jquery ajax
        11- JQuery Datatable
        12- Textbox that only accepts number jquery
        13- Hide website while loading and loader is showing.
         */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult task1to4()
        {
            return View();
        }

        [HttpPost]
        public JsonResult contact_submit(ContactUsVm user)
        {
            bool status = false;
            if(user != null)
            {
                try
                {
                    PeopleWhoContactU tmp = new PeopleWhoContactU();
                    tmp.Name = user.name;
                    tmp.Email = user.email;
                    tmp.Message = user.message;

                    db.PeopleWhoContactUs.Add(tmp);
                    db.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    status = false;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}