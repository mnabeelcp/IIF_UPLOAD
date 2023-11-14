
using IIF_upload.Models.batchsheet;
using System.ComponentModel.DataAnnotations;

namespace IIF_upload.Models.InProgress
{
    public class TBC_Header
    {
        public long ID { get; set; } 
        public long? Batch { get; set; }
        public string? SampleMatrix { get; set; }
        public string? Testmethod { get; set; }
        public DateTime? Dateofanalysis { get; set; }
        public string? Analyst { get; set; }
        //[DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Incubationstart { get; set; }
       
        public DateTime Incubationend { get; set; }
        public string? Media { get; set; }
        public long LotID { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Batch_Status { get; set; }

    }
}



//ID = ID
//Batch= Batch
//SampleMatrix= SampleMatrix
// Testmethod = Testmethod
//Dateofanalysis= Dateofanalysis
//Analyst= Analyst
// Incubationstart= Incubationstart
// Incubationend = Incubationend
//Media = Media
//LotID = LotID
// CreatedUser = CreatedUser
//CreatedDate = CreatedDate
//ModifiedUser = ModifiedUser
//ModifiedDate= ModifiedDate