using Domain.Entities;
using Domain.Models;

namespace Infrastructure.Interface;

public interface IProcessBallot
{
    public void ShowBallotResult(List<CandidatesViewModel> candidatesResult);
    public void ShowWinner(List<CandidatesViewModel> winner);
    public List<CandidatesViewModel> GetWinner(List<CandidatesViewModel> candidatesResult);
    public List<CandidatesViewModel> ProcessToPrint(List<Candidate> canditates);
}
