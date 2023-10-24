using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Rules;

namespace Infrastructure.Service;

public class RegistryCandidateService : IRegistryCandidate
{
    public List<Candidate> RegisterCandidateBallot()
    {
        string aux = "";
        List<Candidate> Candidates = new();

        while (aux != "eof")
        {
            Console.WriteLine("entre com o nome do candidato:");
            var candidateName = Console.ReadLine() ?? "";

            if (InputValidation.ValidateString(candidateName))
            {
                Console.WriteLine("Algo deu errado, por favor tente novamente.");
                continue;
            }
            if (InputValidation.ValidateExit(candidateName))
            {
                break;
            }
            if (InputValidation.ValidateCandidateNameRepetition(Candidates, candidateName))
            {
                Console.WriteLine(
                    $"O candidato {candidateName} já foi registrado, por favor tente outro candidato."
                );
                continue;
            }

            Console.WriteLine("entre com o valor de total de votos do candidato:");
            var candidateVotesQt = Console.ReadLine() ?? "";

            if (InputValidation.ValidateString(candidateVotesQt))
            {
                Console.WriteLine("Algo deu errado, por favor tente novamente.");
                continue;
            }
            if (InputValidation.ValidateExit(candidateVotesQt))
            {
                break;
            }
            if (!InputValidation.ValidateInterger(candidateVotesQt))
            {
                Console.WriteLine(
                    "Ops, parece que você não digitou um numero inteiro valido, por favor tente novamente."
                );
                continue;
            }
            if (InputValidation.ValidateVotesCountRepetition(Candidates, int.Parse(candidateVotesQt)))
            {
                Console.WriteLine(
                    $"Regra de impossibilidade de empates impede que o valor pois poderia impatar com {Candidates.First(e => e.VoteQuantity == int.Parse(candidateVotesQt)).Name} ja tem esta qauntia de votos. Por favor tente novamente."
                );
                continue;
            }

            Candidates.Add(CreateCandidate(candidateName, candidateVotesQt));
        }

        return Candidates;
    }

    private Candidate CreateCandidate(string candidateName, string vote)
    {
        return new Candidate()
        {
            Id = Guid.NewGuid(),
            Name = candidateName,
            VoteQuantity = int.Parse(vote),
        };
    }
}
