using Domain.Entities;
using Domain.Models;

namespace Infrastructure.Interface;

public interface IProcessBallot
{
    public void ShowBallotResult(List<CandidatesViewModel> candidatesResult);
    public void ShowWinner(CandidatesViewModel winner);
    public CandidatesViewModel GetWinner(List<CandidatesViewModel> candidatesResult);
    public List<CandidatesViewModel> ProcessToPrint(List<Candidate> canditates);
}
