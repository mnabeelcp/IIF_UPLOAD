using IIF_upload.data;
using IIF_upload.Models;
using IIF_upload.Models.batchsheet;
using IIF_upload.Models.InProgress;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace IIF_upload.components
{
    public class BselectorViewComponent : ViewComponent
    {
        private readonly LoadBatchfromDb importbatch;

        public BselectorViewComponent(LoadBatchfromDb Importbatch)
        {
            this.importbatch = Importbatch;
        }


        public async Task<IViewComponentResult> InvokeAsync(string types)
        {
            var dsheet1 = importbatch.MasterDataTables.Where(x => x.TestName == types);
            var dsheet = await dsheet1.ToListAsync();
            var Bsheet = importbatch.BatchDetails;
            var Bsheet1 = await Bsheet.ToListAsync();
           

            var filteredBsheet = new List<Batch>();
            foreach (var data in Bsheet1)
            {
                //if (data.BatchID == 313999) 
                //{
                //    var flag1 = false;
                //}
                var flag2 = false;
                foreach (var item in dsheet)
                {
                    if (item.MethodName == data.Method && item.Analyte == data.Analyte)
                    {
                        flag2 = true;
                    };
                }
                if (flag2 == true)
                {
                    filteredBsheet.Add(data);
                }
                ViewBag.testtype = types;
            }
            //var a = Enum.GetName(typeof(TTypes), int.Parse(Type));
            //var temp = new List<Batch>();
            //temp = Bsheet1.Distinct().ToList();
            var BselectviewModel = new BselectorViewData
            {

                Blist = filteredBsheet,
                //Blist = Bsheet1,
                Ttype = "TBC",
            };
            switch(types)
            {
                case "TBC":
                    var tbc_Details1 = importbatch.Test_TBC_Details;
                    var tbc_header1 = importbatch.Test_TBC_Header;
                    var tbc_Details = await tbc_Details1.ToListAsync();
                    var tbc_header = await tbc_header1.ToListAsync();
                    BselectviewModel.Tbc_Details=tbc_Details;
                    BselectviewModel.Tbc_Header = tbc_header;
                    break;




            }
            return View(BselectviewModel);
           //return View(Bsheet1);
        }
    }
}
