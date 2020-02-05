using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bhInterviewWeb.Models;

namespace bhInterviewWeb.Controllers
{
    public class ReasonController : Controller
    {

        public ActionResult Index()
        {
            var listOfReasons = new List<Reason>{
                            new Reason() { ReasonText = "I would like a software engineering job in the downtown Sacramento area." } ,
                            new Reason() { ReasonText = "I believe Berkshire Hathaway is a company where I can grow in my career." } ,
                            new Reason() { ReasonText = "I hope to learn more about software development in my next career position." } ,
                            };
            // Get the students from the database in the real application

            return View(listOfReasons);
        
        }
    }
}
