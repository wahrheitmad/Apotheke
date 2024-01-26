using Apotheke.Models;
using Apotheke.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apotheke.Controllers
{
    public class DrugController : Controller
    {
        Repository repository = new Repository();
        // GET: Drug
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GetImage(int drugId)
        {
            Drug drug = repository.Drugs
                .FirstOrDefault(g => g.DrugID == drugId);

            if (drug != null)
            {
                return File(drug.ImageData, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
    }
}
