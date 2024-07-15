using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoListDbContext _context;

        public HomeController(ILogger<HomeController> logger, ToDoListDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var allLists = _context.Lists.ToList();
            var totalList = allLists.Sum(x => x.Price);
            ViewBag.List = totalList;
            return View(allLists);
        }

        public IActionResult CreateList(int? id)
        {
            if(id != null)
            {
                var listInDb = _context.Lists.SingleOrDefault(x => x.Id == id);
                return View(listInDb);
            }
            
            return View();
        }

        public IActionResult DeleteList(int id)
        {
            var listInDb = _context.Lists.SingleOrDefault(x => x.Id == id);
            _context.Lists.Remove(listInDb);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult AfterCreateList(List model)
        {
            if(model.Id == 0)
            {
                //create
                _context.Lists.Add(model);
            }
            else
            {
                //edit
                _context.Lists.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
