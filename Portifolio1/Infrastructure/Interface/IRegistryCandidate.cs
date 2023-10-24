using Domain.Entities;

namespace Infrastructure.Interface;

public interface IRegistryCandidate
{
    public List<Candidate> RegisterCandidateBallot();
}
