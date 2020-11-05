using Domain.ValueObjects;
using System;

namespace Domain
{
    public class Like :IAuditEntity
    {
        public LikeId LikeId { get; }

        public string Author { get; set; }

        public Like(LikeId likeId, string author, ArticleId articleId)
        {
            LikeId = likeId;
            Author = author;
            ArticleId = articleId;
        }


        public virtual Article Article { get; set; }
        public ArticleId ArticleId { get; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }
        public byte[] RowVersion { get; }
        public void Audit(string userName, AuditType type)
        {
            switch (type)
            {
                case AuditType.Add:
                    CreatedBy = userName;
                    CreatedOn = DateTime.UtcNow;
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
                case AuditType.Modify:
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
                case AuditType.Delete:
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
            }
        }
    }
}
