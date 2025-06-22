namespace Api.Domain;

public abstract class Entity<TId> where TId : notnull
{
    public required TId Id { get; init; }

    /// <summary>
    /// Two entities are considered equal if their Ids are equal.
    /// </summary>
    /// <param name="obj">The object to compare to</param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        // Objects must be of the same type and their Ids must be equal
        return obj is Entity<TId> other 
               && EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <summary>
    ///  Generates a hash code based on the Id of the entity.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }
}