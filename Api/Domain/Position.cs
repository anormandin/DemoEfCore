namespace Api.Domain;

public class Position: Entity<int>
{
    public required string Title { get; init; }
    public required string Description { get; init; }

    
}