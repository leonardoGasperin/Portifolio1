using Domain.Entities;

namespace Infrastructure.Interface;

public interface IRegistryCandidate
{
    public Candidate CreateCandidate(string candidateName, string vote);
}
