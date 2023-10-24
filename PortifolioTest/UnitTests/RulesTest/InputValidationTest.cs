using Domain.Entities;
using Infrastructure.Rules;
using UnitTests.Factory;

namespace RulesTest;

internal class InputValidationTest
{
    [TestCase("")]
    [TestCase(null)]
    [TestCase("5,6")]
    [TestCase("14.5")]
    [TestCase("a")]
    [TestCase("-")]
    [TestCase("14.5 5,6 - * / # ° string")]
    public void ValidateInterger_WhenIsNotInterger(string input)
    {
        Assert.That(InputValidation.ValidateInterger(input), Is.False);
    }

    [Test]
    public void ValidateInterger_WhenIsInterger()
    {
        Assert.That(InputValidation.ValidateInterger("78546"), Is.True);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("   ")]
    public void ValidateString_WhenIsNullOrEmptyOrWhiteSpace(string input)
    {
        Assert.That(InputValidation.ValidateString(input), Is.True);
    }

    [Test]
    public void ValidateString_WhenIsValid()
    {
        Assert.That(InputValidation.ValidateString("Input"), Is.False);
    }

    [TestCase("José Arlindo DaFonseca Ferraz Silva Vermelho")]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("56")]
    [TestCase("14.5")]
    [TestCase("a")]
    [TestCase("-")]
    [TestCase("14.5 5,6 - * / # ° string")]
    public void ValidateExit_WhenIsNotValidInput(string input)
    {
        Assert.That(InputValidation.ValidateExit(input), Is.False);
    }

    [TestCase("eof")]
    [TestCase("Eof")]
    [TestCase("eOf")]
    [TestCase("eoF")]
    [TestCase("EoF")]
    [TestCase("EOf")]
    [TestCase("eOF")]
    [TestCase("EOF")]
    public void ValidateExit_WhenIsValid(string input)
    {
        Assert.That(InputValidation.ValidateExit(input), Is.True);
    }

    [Test]
    public void ValidateCandidateNameRepetition_WhenListIsEmpty()
    {
        List<Candidate> candidates = new();
        Assert.That(InputValidation.ValidateCandidateNameRepetition(candidates, ""), Is.False);
    }

    [Test]
    public void ValidateCandidateNameRepetition_WhenListIsValid_ButInputIsNot()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(3);

        Assert.That(
            InputValidation.ValidateCandidateNameRepetition(candidates, candidates[0].Name),
            Is.True
        );
    }

    [Test]
    public void ValidateCandidateNameRepetition_WhenListAndInputIsValid_AndInputIsNotRepited()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(3);

        Assert.That(
            InputValidation.ValidateCandidateNameRepetition(candidates, "New_Name"),
            Is.False
        );
    }

    [Test]
    public void ValidateVotesCountRepetition_WhenListIsEmpty()
    {
        List<Candidate> candidates = new();

        Assert.That(InputValidation.ValidateVotesCountRepetition(candidates, 0), Is.False);
    }

    [Test]
    public void ValidateVotesCountRepetition_WhenListIsValid_ButInputIsNot()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(3);

        Assert.That(InputValidation.ValidateVotesCountRepetition(candidates, 10), Is.True);
    }

    [Test]
    public void ValidateVotesCountRepetition_WhenListAndInputIsValid_AndInputIsNotRepited()
    {
        var candidates = CandidateFactory.GetMultipleCandidates(3);

        Assert.That(InputValidation.ValidateVotesCountRepetition(candidates, 11), Is.False);
    }
}
