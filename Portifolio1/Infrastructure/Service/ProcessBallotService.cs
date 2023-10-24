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

    public void ShowWinner(List<CandidatesViewModel> winner)
    {
        if (winner == null || winner.Count == 0)
        {
            throw new ArgumentException("lista vazia ou nula");
        }
        if (winner.Count == 1)
        {
            Console.WriteLine(
                $"O candidato {winner[0].Name} venceu a eleição com {winner[0].VoteQuantity} votos."
            );
        }
        else
        {
            Console.WriteLine("Candidatos empatados em primeiro lugar:");
            foreach (var candidate in winner)
            {
                Console.WriteLine(
                    $"O candidato {candidate.Name} empatou a eleição com {candidate.VoteQuantity} votos."
                );
            }
        }
    }

    public List<CandidatesViewModel> GetWinner(List<CandidatesViewModel> candidatesResult)
    {
        int highCount = candidatesResult.Max(e => e.VoteQuantity);

        return candidatesResult.Where(e => e.VoteQuantity == highCount).ToList();
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
