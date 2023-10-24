using Domain.Entities;

namespace UnitTests.Factory;

public static class CandidateFactory
{
    public static Candidate GetCanditate(string Name, int voteQt)
    {
        return new Candidate()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            VoteQuantity = voteQt,
        };
    }

    public static List<Candidate> GetMultipleCandidates(int quantity)
    {
        List<Candidate> candidates = new();

        for (int i = 0; i < quantity; i++)
        {
            candidates.Add(GetCanditate("Name_" + i, i * (3 + i)));
        }

        return candidates;
    }
}
