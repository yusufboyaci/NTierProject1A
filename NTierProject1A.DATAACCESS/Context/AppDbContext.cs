using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTierProject1A.CORE.Entity;
using NTierProject1A.CORE.Methods;
using NTierProject1A.ENTITIES.Entities;
using NTierProject1A.ENTITIES.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1A.DATAACCESS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            NetworkFunctions networkFunctions = new NetworkFunctions();
            List<EntityEntry> modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now.ToUniversalTime();//"Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone', only UTC is supported." hatasını çözmek için kullanıldı.
            string user = Environment.UserName;
            string ip = networkFunctions.GetLocalIpAddress();

            modifiedEntries.ForEach(item =>
            {
                CoreEntity? entity = item.Entity as CoreEntity;
                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedIp = ip;
                        entity.CreatedBy = user;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedIp = ip;
                        entity.ModifiedBy = user;
                    }
                }
            });
            return base.SaveChanges();
        }
    }
}
