using Domain.Entities;
using Domain.Models;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class ProcessBallotService : IProcessBallot
{
    public void ShowBallotResult(List<CandidatesViewModel> candidatesResult)
    {
        if (candidatesResult == null || candidatesResult.Count == 0)
        {
            throw new ArgumentException("lista vazia ou nula");
        }

        int i = 1;
        Console.Clear();
        foreach (var candidate in candidatesResult)
        {
            Console.WriteLine(
                $"Nome do {i}. candidato: {candidate.Name}\nNúmero de votos do 1. candidato: {candidate.VoteQuantity}\n"
            );
            i++;
        }
    }

    public void ShowWinner(CandidatesViewModel winner)
    {
        Console.WriteLine(
                $"O candidato {winner.Name} venceu a eleição com {winner.VoteQuantity} votos."
            );
    }

    public CandidatesViewModel GetWinner(List<CandidatesViewModel> candidatesResult)
    {
        int highCount = candidatesResult.Max(e => e.VoteQuantity);

        return candidatesResult.First(e => e.VoteQuantity == highCount);
    }

    public List<CandidatesViewModel> ProcessToPrint(List<Candidate> canditates)
    {
        return canditates
            .Select(
                e => new CandidatesViewModel() { Name = e.Name, VoteQuantity = e.VoteQuantity, }
            )
            .ToList();
    }
}
