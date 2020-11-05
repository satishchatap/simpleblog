namespace Application.UseCases.ArticleComment
{
    using Domain;

    /// <summary>
    ///     Comment Presenter.
    /// </summary>
    public sealed class LikePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public Comment? Comment { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Comment comment, Article article)
        {
            this.Comment = comment;
            this.Article = article;
        }
    }
}
