using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ISoftDelete
    {
        public DateTime DeletedOn { get; }
        public string DeleteBy { get; }
        public bool IsDeleted { get; }
        public void Audit(string userName);
    }
}
