using AspFinal.AppCode.Constant;
using AspFinal.Models;
using AspFinal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AspFinal.Areas.Admin.Controllers
{
    [CvAuthorization]
    [CVFilter]
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
                person.UpdateDate = DateTime.Now;
                string i = mediaUrl.SaveImage(Server.MapPath("~/Template/Media"));
                person.MediaUrl = i;
            }
            if (ModelState.IsValid)
            {
                personDetails.CreatedDate = DateTime.Now;
                db.PersonDetails.Add(personDetails);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult BioSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BioSkillsPost(Bios bios)
        {
            if (ModelState.IsValid)
            {
                bios.CreatedDate = DateTime.Now;
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
            var category = db.Categories.ToList();
            return View(category);
        }
        public ActionResult Skill()
        {
            var skill = db.Skills.ToList();
            return View(skill);
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
                professionalExperience.CreatedDate = DateTime.Now;
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
        public ActionResult AcademicBackgroundPost(AcademicBackgrounds academicBackgrounds, HttpPostedFileBase Image, string fileName)
        {
            if (Image != null)
            {
                bool valid = true;
                if (!Image.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!Image.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = Image.SaveImage(Server.MapPath("~/Template/Media/"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));


                    academicBackgrounds.MediaUrl = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(academicBackgrounds.MediaUrl)
                && !string.IsNullOrWhiteSpace(fileName))
            {
                academicBackgrounds.MediaUrl = null;
            }
            if (ModelState.IsValid)
            {
                academicBackgrounds.CreatedDate = DateTime.Now;
                db.AcademicBackgrounds.Add(academicBackgrounds);
                db.SaveChanges();
            }
            return RedirectToAction("EditResumeAdmin");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AspFinal.Models.Entity.Admin Admin)
        {
            var Alogin = db.Admin.FirstOrDefault();
            if (Alogin.Email == Admin.Email && Alogin.Password == Admin.Password)
            {

                Session[SessionKey.Admin] = Admin;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginError = "Email or Password not matched";
                return View();
            }
        }
        public ActionResult BioRefresh()
        {
            return View(db.Bios.Where(w => w.DeletedDate == null).ToList());
        }
        [HttpPost]
        public ActionResult DeleteBio(int? DeleteBio)
        {
            var DeleteBioSkill = db.Bios.Where(w => w.DeletedDate == null && w.Id == DeleteBio).FirstOrDefault();
            DeleteBioSkill.DeletedDate = DateTime.Now;
            db.Entry(DeleteBioSkill).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult RefreshAcademicBackground()
        {
            return View(db.AcademicBackgrounds.Where(w => w.DeletedDate == null).ToList());
        }
        [HttpPost]
        public ActionResult DeleteAcademic(int? DeleteAcademic)
        {
            var DeleteAC = db.AcademicBackgrounds.Where(w => w.DeletedDate == null && w.Id == DeleteAcademic).FirstOrDefault();
            DeleteAC.DeletedDate = DateTime.Now;
            db.Entry(DeleteAC).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditResumeAdmin");
        }
        public ActionResult RefreshExperience()
        {
            return View(db.ProfessionalExperience.Where(w => w.DeletedDate == null).ToList());
        }
        [HttpPost]
        public ActionResult DeleteExperience(int? DeleteExperience)
        {
            var DeletePE = db.ProfessionalExperience.Where(w => w.DeletedDate == null && w.Id == DeleteExperience).FirstOrDefault();
            DeletePE.DeletedDate = DateTime.Now;
            db.Entry(DeletePE).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditResumeAdmin");
        }
    }
}