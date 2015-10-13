using System.Web.Mvc;
using FastFoodWebApplication.DataAccess;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonData PersonData;
        public PersonController()
        {
            PersonData = new PersonFromDb();
        }

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel personModel)
        {
            PersonData.CreatePerson(personModel);
            return View();
        }

    }
}