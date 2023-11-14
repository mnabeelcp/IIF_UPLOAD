using IIF_upload.Models.InProgress;
using IIF_upload.Models;
using IIF_upload.Models.batchsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIF_upload.data
{
    public class LoadBatchfromDb : DbContext
    {
        public LoadBatchfromDb(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Batch> BatchDetails { get; set; }
        public DbSet<DataSheet> MasterDataTables { get; set; }
        public DbSet<TBC_Details>? Test_TBC_Details { get; set; }
        public DbSet<TBC_Header>? Test_TBC_Header { get; set; }
       

        public DbSet <IIFoutput> IIFDetails { get; set; }
       
    }
}
