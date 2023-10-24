using Domain.Models;
using Infrastructure.Service;
using System.Reflection;
using UnitTests.Factory;

namespace ServiceTest;

public class ProcessBallotServiceTest
{
    private ProcessBallotService _processBallotService;

    [SetUp]
    public void Setup()
    {
        _processBallotService = new();
    }

    [Test]
    public void GetWinnerTest()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(7).Select(e => new CandidatesViewModel()
        {
            Name = e.Name,
            VoteQuantity = e.VoteQuantity,
        }).ToList();
        var expectedWinner = candidates.First(e => e.VoteQuantity == candidates.Max(l => l.VoteQuantity)) ?? new() { Name = "ERROR" };

        var result = _processBallotService.GetWinner(candidates);

        Assert.That(result, Is.EqualTo(expectedWinner));
    }

    [Test]
    public void ShowWinnerTest()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(7).Select(e => new CandidatesViewModel()
        {
            Name = e.Name,
            VoteQuantity = e.VoteQuantity,
        }).ToList();
        var expectedWinner = candidates.First(e => e.VoteQuantity == candidates.Max(l => l.VoteQuantity)) ?? new() { Name = "ERROR" };
        var expectedConsoleLine = $"O candidato {expectedWinner.Name} venceu a eleição com {expectedWinner.VoteQuantity} votos.";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            _processBallotService.ShowWinner(expectedWinner);

            string consoleOutput = sw.ToString().Trim();

            Assert.That(consoleOutput, Is.EqualTo(expectedConsoleLine));
        }
    }

    [Test]
    public void ProcessToPrintTest()
    {
        var candidate = CandidateFactory.GetMultipleCandidates(7);
        var expectedList = candidate.Select(e => new CandidatesViewModel()
        {
            Name = e.Name,
            VoteQuantity = e.VoteQuantity,
        }).ToList();
        var result = _processBallotService.ProcessToPrint(candidate);

        for (int i = 0; i < expectedList.Count; i++)
        {
            Assert.That(result[i].Name, Is.EqualTo(expectedList[i].Name));
            Assert.That(result[i].VoteQuantity, Is.EqualTo(expectedList[i].VoteQuantity));
        }
    }

    [Test]
    public void ShowBallotResult_whenListIsNull()
    {
        Assert.Throws<ArgumentException>(() => _processBallotService.ShowBallotResult(null));
    }

    [Test]
    public void ShowBallotResult_whenListIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => _processBallotService.ShowBallotResult(new()));
    }
}