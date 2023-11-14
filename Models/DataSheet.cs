using System.ComponentModel.DataAnnotations;

namespace IIF_upload.Models
{
    public class DataSheet
    {
 
            [Key]
            public long methodanalytepairid { get; set; }
            public string? methodanalytelookuppair { get; set; }
            public string? MethodName { get; set; }
            public string TestName { get; set; }

            public string? Analyte { get; set; }
            public string lookuptablename { get; set; }
            public string? Details { get; set; }
            //public double? Worksheet_type { get; set; }
            //public string? Measurementunits { get; set; }
            //public double? Dilution_factor { get; set; }
            //public double? Sample_Amount { get; set; }
            //public double? Final_Amount { get; set; }
            //public double? Calculation_factor { get; set; }
            //public string? Report_Unit { get; set; }
            //public string? Equipment_1 { get; set; }
            //public string? Equipment_2 { get; set; }
            //public string? Equipment_3 { get; set; }
            //public string? Equipment_4 { get; set; }
            //public string? Equipment_5 { get; set; }
            //public string? Equipment_6 { get; set; }
            //public string? Equipment_7 { get; set; }
            //public string? Equipment_8 { get; set; }
            //public string? Equation { get; set; }

	//[MethodName][varchar] (150) NULL,
	//[Analyte][varchar] (100) NULL,
	//[TestName][varchar] (100) NULL,
	//[lookuptablename][varchar] (50) NULL,
	//[Details][varchar] (250) NULL,
	//[CreatedUser][varchar] (50) NULL,
	//[CreatedDate][datetime] NULL,
	//[ModifiedUser][varchar] (50) NULL,
	//[ModifiedDate][datetime] NULL
    }
}
