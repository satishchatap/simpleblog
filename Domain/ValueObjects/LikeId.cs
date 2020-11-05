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
    public readonly struct LikeId : IEquatable<LikeId>
    {
        public Guid Id { get; }

        public LikeId(Guid id) =>
            this.Id = id;

        public override bool Equals(object? obj)
        {
            return obj is LikeId o && this.Equals(o);
        }

        public bool Equals(LikeId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(LikeId left, LikeId right) => left.Equals(right);

        public static bool operator !=(LikeId left, LikeId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}