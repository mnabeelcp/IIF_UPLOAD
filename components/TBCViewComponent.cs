using IIF_upload.data;
using IIF_upload.Models;
using IIF_upload.Models.InProgress;
using IIF_upload.Models.batchsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace IIF_upload.components
{
    public class TBCViewComponent : ViewComponent
    {
        private readonly LoadBatchfromDb importbatch;

        public TBCViewComponent(LoadBatchfromDb Importbatch)
        {
            this.importbatch = Importbatch;
        }


        public async Task<IViewComponentResult> InvokeAsync(long Bid)
        {

            //var a = Enum.GetName(typeof(TTypes), int.Parse(Type));
            var Bsheet = importbatch.BatchDetails.Where(x => x.BatchID == Bid);
            var Bsheet1 = await Bsheet.ToListAsync();
            var dsheet1 = importbatch.MasterDataTables.Where(x => x.TestName == "TBC" && x.Details != null);
            var dsheet = await dsheet1.ToListAsync();
            var iifoutput = new List<IIFoutput>(Bsheet1.Count);
            var Header1 = importbatch.Test_TBC_Header
                .Where(x => x.Batch == Bid);

            //.Select(x => x.ID)
            //.Max();
            var Details1 = importbatch.Test_TBC_Details
                .Where(x => x.Test_TBC_Header_ID == Bid);
            //.Select(x => x.ID)
            //.Max();
            //var header = new object();
            //var details = new object();

            //Console.WriteLine("Before Header1.ToListAsync()");
            var header = await Header1.ToListAsync();
            var details = await Details1.ToListAsync();
            //Console.WriteLine("After Header1.ToListAsync()");

            //var header = await Header1.ToListAsync();




            var batchList = new List<SelectListItem>();
            var filteredDsheet = new List<DataSheet>();

            foreach (var item in dsheet)
            {
                var flag =false;
                foreach (var data in Bsheet1)
                {
                    if (item.MethodName == data.Method && item.Analyte == data.Analyte)
                    {
                        flag = true;
                    };
                }
                if (flag == true)
                {
                    filteredDsheet.Add(item);
                }

            }


            for (int i = 0; i < Bsheet1.Count; i++)
            {
                iifoutput.Add(new IIFoutput
                {
                    BatchID = Bsheet1[i].BatchID,
                    BatchPosition = i + 1,
                    LotID = Bsheet1[i].LotID,
                    SampleID = Bsheet1[i].LotRefNum,
                    UniqueSampleID = Bsheet1[i].SampID,
                    IdentificationType = 2,
                    SampleType = 1,
                    MethodCode = Bsheet1[i].Method,
                    InstrumentCode = Bsheet1[i].Instrument,
                    AnalyteCode = Bsheet1[i].Analyte,
                    //Result
                    Factor = 1,
                    ResultText = "0", //need to checck the actual value from excel
                    ResultType = 1, //need to checck the actual value from excel
                    AcceptFlag = 1, //need to checck the actual value from excel
                    AnalystID = " from global variable ",
                    //Equipment1=
                    //Equipment2
                    //Equipment3
                    //Equipment4
                    //Equipment5
                    //Equipment6
                    CompanyID = "ReadIniFileString(\"Company\", \"ID\")"
                    //Comments
                });
            }

            if (header.Count == 0)
            {
                header.Add(new IIF_upload.Models.InProgress.TBC_Header
                {

                    Batch = Bsheet1[0].BatchID,
                    SampleMatrix = "not in data table",
                    Testmethod = Bsheet1[0].Method,
                    Dateofanalysis = DateTime.Now,
                    Incubationend= DateTime.Now,
                    Incubationstart= DateTime.Now,

                });
                for (int i = 0; i < Bsheet1.Count; i++)
                {
                    details.Add(new IIF_upload.Models.InProgress.TBC_Details
                    {
                        ID=1,
                        Test_TBC_Header_ID = Bsheet1[i].BatchID,
                        Analyte = Bsheet1[i].Analyte,
                        LOTID = Bsheet1[i].LotID,
                        ResultFactor=1,
                        Finalresult=1,
                        UploadtoLIMS = false,

                    });
                }
            }


                var viewModel = new TestSheetViewData
            {
                Batchsheet = Bsheet1,
                Iifout = iifoutput,
                Dsheet = filteredDsheet,
                Tbc_Header = header[0],
                Tbc_Details = details,
                 Ttype="TBC",
                 Mode="save",

                };
            return View(viewModel);
        }

    }
}
