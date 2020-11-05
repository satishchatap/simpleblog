using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Article :IArticle, IAuditEntity
    {      

        public Article(ArticleId articleId,  string title, string body, string summary,string author)
        {
            ArticleId = articleId;
            Title = title;
            Body = body;
            Summary = summary;
            Author = author;
        }

        public ArticleId ArticleId { get; }
        [Column(TypeName = "varchar(50)")]
        public string Author { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; }
        [Column(TypeName = "varchar(200)")]
        public string Summary { get; }
        public string Body { get; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }
        public byte[] RowVersion { get; }
        public DateTime PublishedDate { get; }
        /// <inheritdoc />
        public virtual LikeCollection Likes { get; } = new LikeCollection();
        /// <inheritdoc />
        public virtual CommentCollection Comments { get; } = new CommentCollection();
        /// <inheritdoc />
        public void Comment(Comment comment) => this.Comments.Add(comment);
        /// <inheritdoc />
        public void Like(Like like) => this.Likes.Add(like);

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

        /// <inheritdoc />
        public int LikeCount => this.Likes.Count;
        /// <inheritdoc />
        public int CommentCount => this.Comments.Count;
    }
}
