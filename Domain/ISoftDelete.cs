using System;

namespace Domain
{
    public interface ISoftDelete
    {
        public DateTime DeletedOn { get; }
        public string DeleteBy { get; }
        public bool IsDeleted { get; }
        public void Audit(string userName);
    }
}
