namespace UnitTest
{
    
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Infrastructure.Authentication;
    using Infrastructure;

    /// <summary>
    /// </summary>
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            this.Context = new DataContextFake();
            this.ArticleRepositoryFake = new ArticleRepositoryFake(this.Context);
            this.UnitOfWork = new UnitOfWorkFake();
            this.EntityFactory = new EntityFactory();
            this.TestUserService = new TestUserService();
        }

        public EntityFactory EntityFactory { get; }

        public DataContextFake Context { get; }

        public ArticleRepositoryFake ArticleRepositoryFake { get; }

        public UnitOfWorkFake UnitOfWork { get; }

        public TestUserService TestUserService { get; }
    }
}