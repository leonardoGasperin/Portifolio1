using Infrastructure.Interface;

namespace Apresentation;

public class ElectionSystem
{
    private readonly IProcessBallot _processBallot;
    private readonly IRegistryCandidate _registryCandidate;

    public ElectionSystem(IProcessBallot processBallot, IRegistryCandidate registryCandidate)
    {
        _processBallot = processBallot;
        _registryCandidate = registryCandidate;
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

        var candidates = _registryCandidate.RegisterCandidateBallot();

        var candidatesResult = _processBallot.ProcessToPrint(candidates);

        _processBallot.ShowBallotResult(candidatesResult);

        var winner = _processBallot.GetWinner(candidatesResult);

        _processBallot.ShowWinner(winner);
    }
}
