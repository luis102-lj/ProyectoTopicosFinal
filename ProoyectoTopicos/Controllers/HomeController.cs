using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProoyectoTopicos.Models;

namespace ProoyectoTopicos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static UsersContext context = new UsersContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public ActionResult Regions()
        {
            var consulta = context.Region.ToList();
            return View(consulta);
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Region model)
        {
            if (ModelState.IsValid)
            {
                Region region = new Region
                {
                    RegionId = model.RegionId,
                    RegionDescription = model.RegionDescription
                };
                context.Region.Add(region);
                context.SaveChanges();
                return RedirectToAction("Regions");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var consulta = context.Region.Where(r => r.RegionId.Equals(id)).FirstOrDefault();
            return View(consulta);
        }
        [HttpPost]
        public ActionResult Edit(Region model)
        {
            var consulta= context.Region.Where(r => r.RegionId.Equals(model.RegionId)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                consulta.RegionDescription = model.RegionDescription;
                context.SaveChanges();
                return RedirectToAction("Regions");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var consulta = context.Region.Where(r => r.RegionId.Equals(id)).FirstOrDefault();
            return View(consulta);
        }

    [HttpPost]
    public ActionResult Delete(Region model)
        {
            var consulta = context.Region.Where(r => r.RegionId.Equals(model.RegionId)).FirstOrDefault();
            context.Region.Remove(consulta);
            context.SaveChanges();
            return RedirectToAction("Regions");
        }
    }
}
