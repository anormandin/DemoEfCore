namespace Api.Domain.Entities;

public class Position : Entity<int>
{
    public string Title { get; init; }
    public string Description { get; init; }

    private Position(int id, string title, string description) : base(id)
    {
        Title = title;
        Description = description;
    }
}