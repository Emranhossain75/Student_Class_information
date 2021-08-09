using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentInformation.Models;

namespace StudentInformation.Content
{
    public class StudentinfoController : Controller
    {
        private ClassInfoEntities db = new ClassInfoEntities();

        // GET: Infoes
        public ActionResult Index()
        {
            var infoes = db.Infoes.Include(i => i.ClassName);
            return View(infoes.ToList());
        }
        // GET: Infoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "ClassName1");
            return View();
        }

        // POST: Infoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Admission_Date,ClassId")] Info info)
        {
            if (ModelState.IsValid)
            {
                db.Infoes.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "ClassName1", info.ClassId);
            return View(info);
        }
        
    }
}
