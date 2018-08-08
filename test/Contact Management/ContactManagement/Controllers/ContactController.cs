using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagement.Models;

namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {
        private ContactRepository repo = new ContactRepository(new ContactEntities());
        
        public ActionResult Index()
        {
            try
            {
                return View(repo.All().ToList());   
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }
        
        public ActionResult Details(int id)
        {
            try
            {
                return View(repo.Single(id));
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(contact);
                repo.Add(contact);
                repo.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }
        
        public ActionResult Edit(int id)
        {
            try
            {
                return View(repo.Single(id));
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }


        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                var record = repo.Single(id);
                UpdateModel<Contact>(record);
                if (!ModelState.IsValid)
                    return View(record);
                repo.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var contact = repo.Single(id);
                return View(contact);
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var contact = repo.Single(id);
                repo.Remove(contact);
                repo.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Util.Log(ex);
            }
            return View("Error");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && repo != null)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}