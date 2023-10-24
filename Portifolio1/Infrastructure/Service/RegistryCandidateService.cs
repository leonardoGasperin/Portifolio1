using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class RegistryCandidateService : IRegistryCandidate
{
    public Candidate CreateCandidate(string candidateName, string vote)
    {
        return new Candidate()
        {
            Id = Guid.NewGuid(),
            Name = candidateName,
            VoteQuantity = int.Parse(vote),
        };
    }
}
