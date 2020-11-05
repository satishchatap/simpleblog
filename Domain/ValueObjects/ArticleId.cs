using System;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Object domain driven desing pattern
    /// Entities are mutable.
    /// Entities are highly abstract.
    /// Entities do not need to be serializable.
    /// The entity state should be encapsulated to external access.
    /// </summary>
    public readonly struct ArticleId : IEquatable<ArticleId>
    {
        public Guid Id { get; }

        public ArticleId(Guid id) =>
            this.Id = id;

        public override bool Equals(object? obj)
        {
            return obj is ArticleId o && this.Equals(o);
        }

        public bool Equals(ArticleId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(ArticleId left, ArticleId right) => left.Equals(right);

        public static bool operator !=(ArticleId left, ArticleId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}