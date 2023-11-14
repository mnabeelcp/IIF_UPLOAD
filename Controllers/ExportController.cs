using IIF_upload.data;
using IIF_upload.Models;
using IIF_upload.Models.InProgress;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using IIF_upload.Models.batchsheet;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace IIF_upload.Controllers
{
    public class ExportController : Controller
    {
        private readonly LoadBatchfromDb importbatch;

        public ExportController(LoadBatchfromDb Importbatch)
        {
            importbatch = Importbatch;
        }
        
            //[HttpPost]
            //public async Task<IActionResult> Output(TestSheetViewData formData)
            //{
                
            //for (var i = 0; i < formData.Iifout.Count; i++)
            //    {
            //    //await formData.Iifout[i].AddAsync(IIFoutput);
            //    if (formData.Tbc_Details[i].UploadtoLIMS == true)
            //    {
            //        formData.Iifout[i].Comments = formData.Iifout[0].Comments;
            //        formData.Iifout[i].Equipment1 = formData.Iifout[0].Equipment1;
            //        formData.Iifout[i].Equipment2 = formData.Iifout[0].Equipment2;
            //        formData.Iifout[i].Equipment3 = formData.Iifout[0].Equipment3;
            //        formData.Iifout[i].Equipment4 = formData.Iifout[0].Equipment4;
            //        formData.Iifout[i].Equipment5 = formData.Iifout[0].Equipment5;
            //        formData.Iifout[i].Equipment6 = formData.Iifout[0].Equipment6;



            //        importbatch.IIFDetails.Add(formData.Iifout[i]);

            //    }
            //    else 
            //    {
            //        formData.Iifout.RemoveAt(i);

            //    }
            //}

            //await importbatch.SaveChangesAsync();
            ////var a = Enum.GetName(typeof(TTypes), int.Parse(Type));
            ////var Bsheet = importbatch.BatchA.Where(x => x.BatchID == Batch);
            //return RedirectToAction("Index", "Home");

            //}

        [HttpPost]
        public async Task<IActionResult> Savesheet(TestSheetViewData formData)
        {

            switch (formData.Ttype)
            {
                case "TBC":
                    var Bsheet1 = importbatch.BatchDetails.Where(x => x.BatchID == formData.Tbc_Details[0].Test_TBC_Header_ID);
                    var Bsheet = await Bsheet1.ToListAsync();
                    var existingHeader1 = importbatch.Test_TBC_Header.Where(x => x.Batch == formData.Tbc_Header.Batch);  
                    var existingHeader = await existingHeader1.ToListAsync();
                    
                    if (existingHeader.Count() == 0)

                    {
                        if (formData.Mode == "output") { formData.Tbc_Header.Batch_Status = "completed"; }
                        importbatch.Test_TBC_Header.Add(formData.Tbc_Header);

                        for (var i = 0; i < formData.Tbc_Details.Count; i++)
                        {

                            importbatch.Test_TBC_Details.Add(formData.Tbc_Details[i]);

                        }
                        
                        await importbatch.SaveChangesAsync();
                    }
                    else
                    {
                        
                        var header = await importbatch.Test_TBC_Header.FindAsync(formData.Tbc_Header.Batch);
                       if(header != null)
                        {
                            header.ID = formData.Tbc_Header.ID;
                            header.SampleMatrix = formData.Tbc_Header.SampleMatrix;
                            header.Testmethod = formData.Tbc_Header.Testmethod;
                            header.Dateofanalysis = formData.Tbc_Header.Dateofanalysis;
                            header.Analyst = formData.Tbc_Header.Analyst;
                            header.Incubationstart = formData.Tbc_Header.Incubationstart;
                            header.Incubationend = formData.Tbc_Header.Incubationend;
                            header.Media = formData.Tbc_Header.Media;
                            header.LotID = formData.Tbc_Header.LotID;
                            header.CreatedUser = formData.Tbc_Header.CreatedUser;
                            header.CreatedDate = formData.Tbc_Header.CreatedDate;
                            header.ModifiedUser = formData.Tbc_Header.ModifiedUser;
                            header.ModifiedDate = formData.Tbc_Header.ModifiedDate;
                            header.Batch_Status = "InProgress";
                            if (formData.Mode == "output") { header.Batch_Status = "completed"; }
                        }
                        importbatch.Entry(header).State = EntityState.Modified;
                        
                        importbatch.SaveChanges();
                        for (var i = 0; i < formData.Tbc_Details.Count; i++)
                        {
                            //var detail = await importbatch.Test_TBC_Details.Where(formData.Tbc_Details[i].ID, formData.Tbc_Details[i].Test_TBC_Header_ID);
                            var detail = await importbatch.Test_TBC_Details.FirstOrDefaultAsync(d => d.ID == formData.Tbc_Details[i].ID && d.Test_TBC_Header_ID == formData.Tbc_Details[i].Test_TBC_Header_ID);

                            if (detail != null)
                            {
                                detail.ID = formData.Tbc_Details[i].ID;
                                detail.Test_TBC_Header_ID = formData.Tbc_Details[i].Test_TBC_Header_ID;
                                detail.LOTID = formData.Tbc_Details[i].LOTID;
                                detail.Analyte = formData.Tbc_Details[i].Analyte;
                                detail.numberofreplicates = formData.Tbc_Details[i].numberofreplicates;
                                detail.pre_platingdilution = formData.Tbc_Details[i].pre_platingdilution;
                                detail.samplevolumeplated = formData.Tbc_Details[i].samplevolumeplated;
                                detail.plate1colonies = formData.Tbc_Details[i].plate1colonies;
                                detail.plate2colonies = formData.Tbc_Details[i].plate2colonies;
                                detail.Observation = formData.Tbc_Details[i].Observation;
                                detail.Observationcondition = formData.Tbc_Details[i].Observationcondition;
                                detail.Noconfirmedfortest1Positive = formData.Tbc_Details[i].Noconfirmedfortest1Positive;
                                detail.Finalresult = formData.Tbc_Details[i].Finalresult;
                                detail.UploadtoLIMS = formData.Tbc_Details[i].UploadtoLIMS;
                                detail.CreatedUser = formData.Tbc_Details[i].CreatedUser;
                                detail.CreatedDate = formData.Tbc_Details[i].CreatedDate;
                                detail.ModifiedUser = formData.Tbc_Details[i].ModifiedUser;
                                detail.ModifiedDate = formData.Tbc_Details[i].ModifiedDate;

                            }
                            importbatch.Entry(detail).State = EntityState.Modified;
                        }
                        
                        await importbatch.SaveChangesAsync();
                    }
                    if (formData.Mode == "output")
                    {
                        
                        for (var i = Bsheet.Count-1; i >= 0; i--)
                        {

                            Bsheet[i].Batch_Status = "completed";
                            //importbatch.Entry(Bsheet[i]).State = EntityState.Modified;
                            if (formData.Tbc_Details[i].UploadtoLIMS == true)
                            {
                                formData.Iifout[i].Comments = formData.Iifout[0].Comments;
                                formData.Iifout[i].Equipment1 = formData.Iifout[0].Equipment1;
                                formData.Iifout[i].Equipment2 = formData.Iifout[0].Equipment2;
                                formData.Iifout[i].Equipment3 = formData.Iifout[0].Equipment3;
                                formData.Iifout[i].Equipment4 = formData.Iifout[0].Equipment4;
                                formData.Iifout[i].Equipment5 = formData.Iifout[0].Equipment5;
                                formData.Iifout[i].Equipment6 = formData.Iifout[0].Equipment6;



                                importbatch.IIFDetails.Add(formData.Iifout[i]);

                            }
                            else
                            {
                                formData.Iifout.RemoveAt(i);

                            }
                        }
                        for (var i = 0; i < Bsheet.Count; i++)
                        {
                            var existingEntity = importbatch.BatchDetails.Local.SingleOrDefault(e => e.LotRefNum == Bsheet[i].LotRefNum);

                            if (existingEntity != null)
                            {
                                importbatch.Entry(existingEntity).State = EntityState.Detached;
                            }

                            importbatch.Entry(Bsheet[i]).State = EntityState.Modified;

                        }
                        await importbatch.SaveChangesAsync();



                    }
                    break;
                  


            }

                return RedirectToAction("Index", "Home");

        }
       

       


    }
}
