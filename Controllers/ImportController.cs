
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IIF_upload.Models.batchsheet;
using System.ComponentModel.Design;
using System.Numerics;
using System.Xml.Linq;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using IIF_upload.Models;
using IIF_upload.data;
using Microsoft.AspNetCore.Http;

namespace IIF_upload.Controllers
{
    public class ImportController : Controller
    {
        private readonly LoadBatchfromDb importbatch;

        public ImportController(LoadBatchfromDb Importbatch)
        {
            importbatch = Importbatch;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index( string Type)
        //{
        //    var a = Enum.GetName(typeof(TTypes), int.Parse(Type));
        //    var Bsheet = importbatch.BatchDetails;
        //    var Bsheet1 = await Bsheet.ToListAsync();
        //    var dsheet = importbatch.MasterDataTables.FirstOrDefault(x => x.methodanalytelookuppair == Bsheet1[0].Method+"-"+ Bsheet1[0].Analyte && x.TestName == Type);
           
        //    var iifoutput = new List<IIFoutput>(Bsheet1.Count);

        //    for (int i = 0; i < Bsheet1.Count; i++)
        //    {
        //        iifoutput.Add(new IIFoutput
        //        {
        //            BatchID = Bsheet1[i].BatchID,
        //            BatchPosition = i + 1,
        //            LotID = Bsheet1[i].LotID,
        //            SampleID = Bsheet1[i].LotRefNum,
        //            UniqueSampleID = Bsheet1[i].SampID,
        //            IdentificationType = 2,
        //            SampleType = 1,
        //            MethodCode = Bsheet1[i].Method,
        //            InstrumentCode = Bsheet1[i].Instrument,
        //            AnalyteCode = Bsheet1[i].Analyte,
        //            //Result
        //            Factor = 1,
        //            ResultText = "0", //need to checck the actual value from excel
        //            ResultType = 1, //need to checck the actual value from excel
        //            AcceptFlag = 1, //need to checck the actual value from excel
        //            AnalystID = " from global variable ",
        //            //Equipment1=
        //            //Equipment2
        //            //Equipment3
        //            //Equipment4
        //            //Equipment5
        //            //Equipment6
        //            CompanyID = "ReadIniFileString(\"Company\", \"ID\")"
        //            //Comments
        //        });
        //    }




        //    var viewModel = new TestSheetViewData
        //    {
        //        Batchsheet = Bsheet1,
        //        Iifout = iifoutput,
        //        //Dsheet= dsheet
        //    };
           

        //    return View(a, viewModel);  // a means the type number in enum
        //}
        [HttpPost]
        public async Task<IActionResult> Output(TestSheetViewData formData)
        {
            List<IIFoutput> iifoutList = formData.Iifout;
            for (var i = 0; i < iifoutList.Count; i++)
            {
                //await iifoutList[i].AddAsync(Export);
                importbatch.IIFDetails.Add(iifoutList[i]);
                iifoutList[i].Comments = iifoutList[0].Comments;
                iifoutList[i].Equipment1 = iifoutList[0].Equipment1;
                iifoutList[i].Equipment2 = iifoutList[0].Equipment2;
                iifoutList[i].Equipment3 = iifoutList[0].Equipment3;
                iifoutList[i].Equipment4 = iifoutList[0].Equipment4;
                iifoutList[i].Equipment5 = iifoutList[0].Equipment5;
                iifoutList[i].Equipment6 = iifoutList[0].Equipment6;



                await importbatch.SaveChangesAsync();

            }

            //var a = Enum.GetName(typeof(TTypes), int.Parse(Type));
            //var Bsheet = importbatch.BatchA.Where(x => x.BatchID == Batch);
            return RedirectToAction("Index", "Home");

        }


    }
}
