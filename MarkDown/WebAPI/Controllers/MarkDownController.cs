using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class MarkDownController : Controller
    {
        // GET: MarkDownController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MarkDownController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarkDownController/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
