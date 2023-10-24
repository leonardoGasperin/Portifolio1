using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Rules;

namespace Apresentation;

public class ElectionSystem
{
    private readonly IProcessBallot _processBallot;
    private readonly IRegistryCandidate _registryCandidate;
    private List<Candidate> _candidates;

    public ElectionSystem(
        IProcessBallot processBallot,
        IRegistryCandidate registryCandidate,
        List<Candidate> candidates
    )
    {
        _processBallot = processBallot;
        _registryCandidate = registryCandidate;
        _candidates = candidates;
    }

    public void Start()
    {
        Console.WriteLine(
            "ola, a seguir voce ira adicionar os candidatos e o número de votos recebidos por cada candidato.\nPrecione \u001b[32menter\u001b[0m para continuar:"
        );
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine(
            "para encerrar o processo a qualquer momento é só digitar \u001b[32meof\u001b[0m e precioanr \u001b[32menter\u001b[0m para sair"
        );

        CandidateRegitryForm();

        var candidatesResult = _processBallot.ProcessToPrint(_candidates);

        _processBallot.ShowBallotResult(candidatesResult);

        var winner = _processBallot.GetWinner(candidatesResult);

        _processBallot.ShowWinner(winner);
    }

    public void CandidateRegitryForm()
    {
        while (true)
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
            if (
                _candidates.Count > 0
                && InputValidation.ValidateCandidateNameRepetition(_candidates, candidateName)
            )
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
            if (
                InputValidation.ValidateVotesCountRepetition(
                    _candidates,
                    int.Parse(candidateVotesQt)
                )
            )
            {
                Console.WriteLine(
                    $"Regra de impossibilidade de empates impede que o valor pois poderia impatar com {_candidates.First(e => e.VoteQuantity == int.Parse(candidateVotesQt)).Name} ja tem esta qauntia de votos. Por favor tente novamente."
                );
                continue;
            }

            _candidates.Add(_registryCandidate.CreateCandidate(candidateName, candidateVotesQt));
        }
    }
}
