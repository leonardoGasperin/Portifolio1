using Domain.Entities;
using Infrastructure.Service;

namespace ServiceTest;

public class RegistryCandidateServiceTest
{
    private RegistryCandidateService _registryCandidateService;

    [SetUp]
    public void Setup()
    {
        _registryCandidateService = new();
    }

    [Test]
    public void CreateCandidateTest()
    {
        var expectedName = "name";
        var expectedVotesQt = 50;

        var expected = new Candidate()
        {
            Id = Guid.NewGuid(),
            Name = expectedName,
            VoteQuantity = expectedVotesQt,
        };

        var candidateResult = _registryCandidateService.CreateCandidate(expectedName, expectedVotesQt.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(candidateResult, Is.Not.Null);
            Assert.That(candidateResult.Id, Is.Not.Empty);
            Assert.That(candidateResult.Name, Is.EqualTo(expected.Name));
            Assert.That(candidateResult.VoteQuantity, Is.EqualTo(expected.VoteQuantity));
        });
    }
}
