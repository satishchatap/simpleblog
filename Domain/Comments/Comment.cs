using Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Comment: IAuditEntity
   {
        public CommentId CommentId { get; }

        [Column(TypeName = "varchar(50)")]
        public string Author { get; set; }
        public Comment(CommentId commentId, ArticleId articleId, string description, string author)
        {
            CommentId = commentId;
            ArticleId = articleId;
            Description = description;
            Author = author;
        }

        public string Description { get; }

        public virtual Article Article { get; set; }
        public ArticleId ArticleId { get; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }
        public byte[] RowVersion { get;}
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
