namespace Domain.Entities;

public class Candidate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int VoteQuantity { get; set; }
}
