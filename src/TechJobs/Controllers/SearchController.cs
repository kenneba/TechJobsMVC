using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                if (searchTerm == null) { 
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else
            {
                 List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                 ViewBag.columns = ListController.columnChoices;
                    ViewBag.title = "All " + ViewBag.columns[searchType] + " Values";
                    ViewBag.jobs = jobs;
                 return View("Index");
                }
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "All " + ViewBag.columns[searchType] + " Values";
                ViewBag.column = searchType;
                ViewBag.searchTerm = searchTerm;
                ViewBag.jobs = jobs;

                return View("Index");
            }
        }

        
    }
}
