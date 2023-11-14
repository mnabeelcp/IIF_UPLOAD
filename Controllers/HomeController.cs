using IIF_upload.data;
using IIF_upload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace batch_import.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoadBatchfromDb importbatch;

        public HomeController(LoadBatchfromDb Importbatchnumber)
        {
            importbatch = Importbatchnumber;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var Bsheet1 = await importbatch.BatchDetails
                 .Where(x => x.BatchID != null)
                 .Select(x => x.BatchID)
                 .ToListAsync();
            List<Int64> temp = Bsheet1.Distinct().ToList();

            return View();
            //return View(Bsheet1);
        }
        //[HttpPost]
        //public ActionResult Index(TTypes type, String Batch)
        //{
        //    return RedirectToAction("Index", "Import", new { selecetdValue = type },Batch);

        //}



        public IActionResult VCbselector(string VCname)
        {
            

            // Invoke the view component and return it as a partial view
            var result = ViewComponent("Bselector", new { types = VCname });
 
            return (result);
        }
        public IActionResult VCcall(long batchnumber)
        {
          

            // Invoke the view component and return it as a partial view
            var result = ViewComponent("TBC", new { Bid = batchnumber });

            return (result);
        }
    }
}