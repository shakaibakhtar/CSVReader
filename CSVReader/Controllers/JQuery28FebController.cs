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

        1- Jquery Rich Textbox (jqueryte plugin css file & js file)
        2- Modify DOM (Change button color etc)
        3- Validations (If textbox is empty change it's border color and bg to red)
        4- Contact us form submit with validations
        5- Populate select option with jquery ajax
        6- Append to DOM Insert(), InsertAfter(), InsertBefore(), Before()
        7- External JS
        8- Add table in DOM using JQuery
        9- ProgressBar Jquery (jquery-ui-1.12.1 css file & js file)
        10- CRUD in Table using jquery ajax
        11- JQuery Datatable (datatables plugin css file, js file & icon images) // Visit this link for help "https://datatables.net/examples/data_sources/"
        12- Textbox that only accepts number jquery
        13- Hide website while loading and loader is showing.
        14- Urdu Keyboard
         */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult task1to5()
        {
            return View();
        }

        public ActionResult task6to8()
        {
            return View();
        }

        public ActionResult task9to10()
        {
            return View();
        }

        public ActionResult task11to13() // Visit this link for help "https://datatables.net/examples/data_sources/"
        {
            return View();
        }

        [HttpPost]
        public JsonResult contact_submit(ContactUsVm user)
        {
            bool status = false;
            if (user != null)
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

        public JsonResult getListOfPeopleContactedUs()
        {
            return Json(db.PeopleWhoContactUs.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        #region CRUD

        public ActionResult getListOfPeople()
        {
            try
            {
                List<ContactUsVm> abc = (from a in db.PeopleWhoContactUs
                                         select new ContactUsVm
                                         {
                                             id = a.ID,
                                             name = a.Name,
                                             email = a.Email,
                                             message = a.Message
                                         }).ToList();

                return View(abc);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public JsonResult add(ContactUsVm contact)
        {
            bool status = false;

            try
            {
                var dbContact = new PeopleWhoContactU();

                dbContact.Name = contact.name;
                dbContact.Email = contact.email;
                dbContact.Message = contact.message;

                db.PeopleWhoContactUs.Add(dbContact);
                db.SaveChanges();

                status = true;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult edit(ContactUsVm contact)
        {
            bool status = false;

            try
            {
                var dbContact = db.PeopleWhoContactUs.Where(x => x.ID == contact.id).FirstOrDefault();

                if (dbContact != null)
                {
                    dbContact.Name = contact.name;
                    dbContact.Email = contact.email;
                    dbContact.Message = contact.message;

                    db.SaveChanges();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult remove(int id)
        {
            bool status = false;

            try
            {
                var dbContact = db.PeopleWhoContactUs.Where(x => x.ID == id).FirstOrDefault();

                if (dbContact != null)
                {
                    db.PeopleWhoContactUs.Remove(dbContact);
                    db.SaveChanges();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return new JsonResult { Data = new { status = status } };
        }

        #endregion

    }
}