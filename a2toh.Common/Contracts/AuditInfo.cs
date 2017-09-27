using System;

namespace FRS.Common.Contracts
{
    public abstract class AuditInfo
    {
        public string CreationUser { get; set; }
        public string LastModificationUser { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModificationDateTime { get; set; }
    }
}
