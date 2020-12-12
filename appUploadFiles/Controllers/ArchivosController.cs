using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appUploadFiles.Models;

namespace appUploadFiles.Controllers
{
    public class ArchivosController : Controller
    {
        // GET: Arcvhios
        public ActionResult Index()
        {
            if(TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"];
            }
            string wwwPath = Server.MapPath("~/");
            string[] filesEntries = Directory.GetFiles(wwwPath + "/files");
            ViewBag.filesEntries = filesEntries;


            var onlyFileNames = new List<string>();
            foreach (string fn in ViewBag.filesEntries)
            {
                onlyFileNames.Add(Path.GetFileName(fn));
            }

            var myArrayWithFN = onlyFileNames.ToArray();

            ViewBag.myArrayFN = myArrayWithFN;

            return View();
        }


        public ActionResult SaveFiles(FileToUploadViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            
            
            string wwwPath = Server.MapPath("~/");
            string pathFiles = Path.Combine(wwwPath + "/files/");

            model.fileUpload01.SaveAs(pathFiles + model.fileUpload01.FileName);
            model.fileUpload02.SaveAs(pathFiles + model.fileUpload02.FileName);
            TempData["msg"] = "Archivos almacenados en la nube";

            return RedirectToAction("Index");
        }
    }
}