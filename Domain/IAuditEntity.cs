using System;

namespace Domain
{
    public interface IAuditEntity
    {
        public DateTime CreatedOn { get; }
        public DateTime ModifiedOn { get; }
        public string CreatedBy { get; }
        public string ModifiedBy { get; }

        public void Audit(string userName, AuditType type);
    }
    public enum AuditType
    {
        Add,Modify,Delete
    }
}
