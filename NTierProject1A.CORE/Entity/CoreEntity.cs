using NTierProject1A.CORE.Enum;
using NTierProject1A.CORE.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1A.CORE.Entity
{
    public abstract class CoreEntity : IEntity<Guid>
    {
        NetworkFunctions networkFunctions = new NetworkFunctions();
        public CoreEntity()
        {
            Status = Status.None;
            CreatedDate= DateTime.Now.ToUniversalTime();//"Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone', only UTC is supported." hatasını çözmek için kullanıldı.Internet tten UTC yi DateTime a çeviren site bul ordan çevirme yap.
            CreatedADUserName = WindowsIdentity.GetCurrent().Name;
            CreatedComputerName = Environment.MachineName;
            CreatedIp = networkFunctions.GetLocalIpAddress();
            CreatedBy = Environment.UserName;
        }
        public Guid Id { get; set; }
        public Guid? MasterId { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIp { get; set; }
        public string? CreatedADUserName { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string? ModifiedComputerName { get; set; }
        public string? ModifiedIp { get; set; }
        public string? ModifiedADUserName { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
