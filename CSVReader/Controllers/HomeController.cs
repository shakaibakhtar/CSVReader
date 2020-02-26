using CSVReader.Models;
using OfficeOpenXml;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSVReader.Controllers
{
    public class HomeController : Controller
    {
        AgentsRecordsEntities db = new AgentsRecordsEntities();

        public ActionResult Index()
        {
            return RedirectToAction("UploadImage");
            //return View();
        }

        public ActionResult UploadImage()
        {
            List<UploadsVM> files = new List<UploadsVM>();

            var dbFiles = db.Uploads.ToList();

            foreach(var file in dbFiles) {
                UploadsVM tmp = new UploadsVM();
                tmp.fileName = file.FileName;
                tmp.filePath = file.FilePath;

                files.Add(tmp);
            }

            return View(files);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    _FileName = _FileName.Replace(" ", "_");
                    string _path = Path.Combine(Server.MapPath("~/Uploads"), _FileName);

                    Upload _upload = new Upload();
                    _upload.FileName = _FileName;
                    _upload.FilePath = _path;
                    db.Uploads.Add(_upload);
                    db.SaveChanges();

                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Export(string GridHtml)
        {
            Document document = new Document();
            document.LoadFromFile(GridHtml, FileFormat.Html, XHTMLValidationType.None);
            document.SaveToFile("test.doc", FileFormat.Doc);


            return RedirectToAction("Contact");

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Grid.doc");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-word";
            //Response.Output.Write(GridHtml);
            //Response.Flush();
            //Response.End();
        }

        [HttpPost]
        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var usersList = new List<RegisterAgentsVM>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var user = new RegisterAgentsVM();
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                                user.Name = workSheet.Cells[rowIterator, 1].Value.ToString();
                            user.Phone = workSheet.Cells[rowIterator, 2].Value.ToString();
                            if (workSheet.Cells[rowIterator, 3].Value != null)
                                user.Plot_Location = workSheet.Cells[rowIterator, 3].Value.ToString();
                            if (workSheet.Cells[rowIterator, 4].Value != null)
                                user.Plot_Size = workSheet.Cells[rowIterator, 4].Value.ToString();
                            if (workSheet.Cells[rowIterator, 5].Value != null)
                                user.Plot_No = workSheet.Cells[rowIterator, 5].Value.ToString();

                            usersList.Add(user);

                            //try
                            //{
                            if (db.RegisterContacts.Where(x => x.Phone == user.Phone).FirstOrDefault() == null)
                            {
                                var dbUser = new RegisterContact();
                                dbUser.Name = user.Name;
                                dbUser.Phone = user.Phone;
                                dbUser.Plot_Location = user.Plot_Location;
                                dbUser.Plot_Size = user.Plot_Size;
                                dbUser.Plot_No = user.Plot_No;

                                db.RegisterContacts.Add(dbUser);
                                db.SaveChanges();
                            }
                            //}
                            //catch(Exception ex)
                            //{
                            //}
                        }

                        return View(usersList);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult CV()
        {
            return View();
        }

        public ActionResult About(List<RegisterAgentsVM> id)
        {
            return View(id);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}