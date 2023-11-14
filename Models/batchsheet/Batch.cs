using System.ComponentModel.DataAnnotations;

namespace IIF_upload.Models.batchsheet
{
    public class Batch
    {

        public Int64 BatchID { get; set; }
        public Int64 LotID { get; set; }
        [Key]
        public Int64 LotRefNum { get; set; }
        public Int64 SampID { get; set; }
        public string SampleMatrix { get; set; }
        public string Method { get; set; }
        public string Analyte { get; set; }
        public DateTime? RecDate { get; set; }
        public string? Instrument { get; set; }
        public decimal? Mean { get; set; }
        public decimal? StandardDeviation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedUser { get; set; }
        public string? Batch_Status { get; set; }

    }
	//[CreatedUser][varchar] (50) NULL,
	//[CreatedDate][datetime] NULL,
	//[ModifiedUser][varchar] (50) NULL,
	//[ModifiedDate][datetime] NULL

}
