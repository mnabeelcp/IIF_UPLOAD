using IIF_upload.Models.batchsheet;
using IIF_upload.Models.InProgress;

namespace IIF_upload.Models
{
    public class BselectorViewData
    {
        public List<Batch>? Blist { get; set; }
        public string Ttype { get; set; }
        public List<TBC_Details>? Tbc_Details { get; set; }
        public List<TBC_Header>? Tbc_Header { get; set; }
        
    }
}
