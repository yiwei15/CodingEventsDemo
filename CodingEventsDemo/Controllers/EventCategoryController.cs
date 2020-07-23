using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "Categories:";
            List<EventCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        [Route("EventCategory/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }


        [HttpPost]
        [Route("EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory(addEventCategoryViewModel.Name);

                context.Categories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View(addEventCategoryViewModel);
        }

    }
}
