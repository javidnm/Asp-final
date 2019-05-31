using AspFinal.Models;
using AspFinal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspFinal.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        AspFinalDbContext db = new AspFinalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditResumeAdmin()
        {
            return View();
        }
        
        public  ActionResult PersonDetails()
        {
            
            return View(db.PersonDetails.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult PersonDetailsPost(PersonDetails personDetails,HttpPostedFileBase mediaUrl)
        {
            if (db.PersonDetails.Any())
            {
                var person = db.PersonDetails.FirstOrDefault();
                person.Age = personDetails.Age;
                person.Name = personDetails.Name;
                person.Phone = personDetails.Phone;
                person.MediaUrl = personDetails.MediaUrl;
                person.Location = personDetails.Location;
                person.Fax = personDetails.Fax;
                person.Email = personDetails.Email;
                person.Degree = personDetails.Degree;
                person.CareerLevel = personDetails.CareerLevel;
                person.Experience = personDetails.Experience;
                person.Website = personDetails.Website;
                string i = mediaUrl.SaveImage(Server.MapPath("~/Template/Media"));
                person.MediaUrl = i;
            }
            if (ModelState.IsValid)
            {
                db.PersonDetails.Add(personDetails);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult BioSkills(Bios bios)
        {
            ViewBag.CategoriesId = new SelectList(db.Categories, "Id", "Name", bios.CategoriesId);
            ViewBag.SkillsId = new SelectList(db.Skills, "Id", "Name", bios.SkillsId);
            return View(bios);
        }
        [HttpPost]
        public ActionResult BioSkillsPost(Bios bios)
        {
            if (ModelState.IsValid)
            {
                db.Bios.Add(bios);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult Bio()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult Skill()
        {
            return View();
        }
        public ActionResult Experience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperiencePost(ProfessionalExperience professionalExperience)
        {
           
            if (ModelState.IsValid)
            {
                db.ProfessionalExperience.Add(professionalExperience);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult AcademicBackground()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AcademicBackgroundPost(AcademicBackgrounds academicBackgrounds)
        {
           
            if (ModelState.IsValid)
            {
                db.AcademicBackgrounds.Add(academicBackgrounds);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
    }
}