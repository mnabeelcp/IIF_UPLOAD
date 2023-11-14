using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IIF_upload.Models
{
    public class IIFoutput
    {
    
        public Int64 BatchID { get; set; }
        [Key]
        public int BatchPosition { get; set; }
        public Int64 LotID { get; set; }

        
        public Int64 SampleID { get; set; }
        public Int64 UniqueSampleID { get; set; }
        public int IdentificationType { get; set; }
        public int SampleType { get; set; }
        public string MethodCode { get; set; }
     
        public string AnalyteCode { get; set; }
        public string InstrumentCode { get; set; }
        public long Result { get; set; }
        public long Factor { get; set; }
        public string ResultText { get; set; }
        public int ResultType { get; set; }
        public int AcceptFlag { get; set; }
        public string AnalystID { get; set; }
        public string Equipment1 { get; set; }
        public string Equipment2 { get; set; }
        public string Equipment3 { get; set; }
        public string Equipment4 { get; set; }
        public string Equipment5 { get; set; }
        public string Equipment6 { get; set; }
        public string CompanyID { get; set; }
        public string Comments { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }


    }
}
