namespace Api.Domain.Entities;

public class Position: Entity<int>
{
    public required string Title { get; init; }
    public required string Description { get; init; }

    
}