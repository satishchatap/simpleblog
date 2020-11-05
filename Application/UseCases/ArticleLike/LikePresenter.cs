namespace Application.UseCases.ArticleLike
{
    using Domain;

    /// <summary>
    ///     Like Presenter.
    /// </summary>
    public sealed class LikePresenter : IOutputPort
    {
        public Article? Article { get; private set; }
        public Like? Like { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Like like, Article article)
        {
            this.Like = like;
            this.Article = article;
        }
    }
}
