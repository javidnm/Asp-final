using AspFinal.Models;
using AspFinal.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AspFinal.Controllers
{

    [CVFilter]
    public class HomeController : Controller
    {

        AspFinalDbContext db = new AspFinalDbContext();
        public ActionResult Index()
        {
            return View(db.PersonDetails.FirstOrDefault());
        }

        
        public ActionResult Contact()
        {
            return View(db.PersonDetails.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Contact(Contact emailModel)
        {
            if (emailModel.Name == null || emailModel.Email == null || emailModel.Content == null)
            {
                TempData["fill"] = "Name,Email,and Body must be written";
                return RedirectToAction("Contact");
            }
            if (ModelState.IsValid)
            {
                db.Contact.Add(emailModel);
                db.SaveChanges();
                Extension.SendMail(emailModel.Subject, emailModel.Content, emailModel.Email);
                return RedirectToAction("Contact");
            }
            return RedirectToAction("Contact");
        }
        public ActionResult Resume()
        {
            return View();
        }
        public ActionResult BioSkills()
        {
            var bios = db.Bios.OrderByDescending(b => b.IsBar == true).Where(w => w.DeletedDate == null).ToList();
            return View(bios);
        }
        public ActionResult AcademicBackground()
        {
            return View();
        }
        public ActionResult Experience()
        {
            return View();
        }
        public ActionResult Sidebar()
        {
            return View(db.PersonDetails.FirstOrDefault());
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult ErrorHistory()
        {
            return View();
        }

    }
}