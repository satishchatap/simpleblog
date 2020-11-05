namespace WebApi.Modules
{
    using Application.Services;
    using Application.UseCases.ArticleComment;
    using Application.UseCases.ArticleLike;
    using Application.UseCases.CreateArticle;
    using Application.UseCases.DeleteArticle;
    using Application.UseCases.EditArticle;
    using Application.UseCases.GetAllArticles;
    using Application.UseCases.GetArticle;
    using Application.UseCases.GetArticles;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Validation, Validation>();

            services.AddScoped<ICreateArticleUseCase, CreateArticleUseCase>();
            services.Decorate<ICreateArticleUseCase, CreateArticleValidationUseCase>();

            services.AddScoped<ICommentUseCase, CommentUseCase>();
            services.Decorate<ICommentUseCase, CommentValidationUseCase>();

            services.AddScoped<ILikeUseCase, LikeUseCase>();
            services.Decorate<ILikeUseCase, LikeValidationUseCase>();

            services.AddScoped<IGetArticleUseCase, GetArticleUseCase>();
            services.Decorate<IGetArticleUseCase, GetArticleValidationUseCase>();

            services.AddScoped<IEditArticleUseCase, EditArticleUseCase>();
            services.Decorate<IEditArticleUseCase, EditArticleValidationUseCase>();

            services.AddScoped<IDeleteArticleUseCase, DeleteArticleUseCase>();
            services.Decorate<IDeleteArticleUseCase, DeleteArticleValidationUseCase>();

            services.AddScoped<IGetArticlesUseCase, GetArticlesUseCase>();

            services.AddScoped<IGetAllArticlesUseCase, GetAllArticlesUseCase>();

            return services;
        }
    }
}
