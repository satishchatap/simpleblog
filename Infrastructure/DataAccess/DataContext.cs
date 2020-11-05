namespace Infrastructure.DataAccess
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;

    /// <inheritdoc />
    public sealed class DataContext : DbContext
    {
        /// <summary>
        /// </summary>
        /// <param name="options"></param>

        public DataContext(DbContextOptions options)
            : base(options)
        {
            SubscribeStateChangeEvents();
        }

        /// <summary>
        ///     Gets or sets Articles
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        ///     Gets or sets Comments
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
        ///     Gets or sets Likes
        /// </summary>
        public DbSet<Like> Likes { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder
                    .UseLazyLoadingProxies();
        void SubscribeStateChangeEvents()
        {
            ChangeTracker.Tracked += OnEntityTracked;
            ChangeTracker.StateChanged += OnEntityStateChanged;
        }
        void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            ProcessLastModified(e.Entry);
        }
        void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery)
                ProcessLastModified(e.Entry);
        }
        void ProcessLastModified(EntityEntry entry)
        {
            if ( entry.State == EntityState.Added)
            {
                var property = entry.Metadata.FindProperty("ModifiedOn");
                if (property != null && property.ClrType == typeof(DateTime))
                    entry.CurrentValues[property] = DateTime.UtcNow;
                property = entry.Metadata.FindProperty("CreatedOn");
                if (property != null && property.ClrType == typeof(DateTime))
                    entry.CurrentValues[property] = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                var property = entry.Metadata.FindProperty("ModifiedOn");
                if (property != null && property.ClrType == typeof(DateTime))
                    entry.CurrentValues[property] = DateTime.UtcNow;
            }
        }
    }
}
