using IIF_upload.Models.batchsheet;
using IIF_upload.Models.InProgress;

namespace IIF_upload.Models
{
    public class TestSheetViewData
    {
        internal object iifout;

        public string Ttype { get; set; }
        public string Mode { get; set; }
        public List<TBC_Details> Tbc_Details { get; set; }
        public TBC_Header Tbc_Header { get; set; }
        public List<DataSheet>? Dsheet { get; set; }
        public List<Batch>? Batchsheet { get; set; }
        public List<IIFoutput>? Iifout { get; set; }
    }
}
