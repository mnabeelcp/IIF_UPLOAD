using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IIF_upload.Models.InProgress
{
    public class TBC_Details
    {
        [Key]
        public long ID { get; set; } //from vc
        public long Test_TBC_Header_ID { get; set; }  //check what means by ID //from vc
        public long LOTID { get; set; } //from vc
        public string Analyte { get; set; }  //[Analyte] [int] NULL, //from vc
        public int? numberofreplicates { get; set; }
        public int? pre_platingdilution { get; set; }
        public string? samplevolumeplated { get; set; }  // int in  another model
        public string? plate1colonies { get; set; }
        public string? plate2colonies { get; set; }
        public string? Observation { get; set; }
        public string? Observationcondition { get; set; }
        public string? Noconfirmedfortest1Positive { get; set; }
        //public decimal Result { get; set; }
        public long? ResultFactor { get; set; }
        public long? Finalresult { get; set; }
        public bool UploadtoLIMS { get; set; }//  int in DB
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

	
	

}
