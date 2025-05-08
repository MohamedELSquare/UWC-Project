using DAL.Models;
using DAL.Models.Difinitions;
using DAL.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class RealTimeContext : DbContext
    {
        public RealTimeContext(DbContextOptions<RealTimeContext> options) : base(options) { }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagDirection> TagDirections { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Alarms> Alarms { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }



        #region Definitions
        public DbSet<DWarehouse> DWarehouses { get; set; }
        public DbSet<DCustomer> DCustomers { get; set; }
        public DbSet<DGate> DGate { get; set; }
        public DbSet<DSensor> DSensors { get; set; }
        public DbSet<SubCustomer> SubCustomers { get; set; }

        #endregion

        #region
        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<Pallet> Palletss { get; set; }

        #endregion


        #region

        #endregion

        public DbSet<PalletTrackingHistory> PalletTrackingHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pallet>()
                .Property(p => p.Status)
                .HasConversion<string>();
            modelBuilder.Entity<PalletTrackingHistory>()
                .HasNoKey()
                .ToView("vw_PalletTrackingHistory", schema: "dbo");

        }
    }



}
