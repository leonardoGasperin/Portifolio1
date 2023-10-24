using Domain.Entities;

namespace Infrastructure.Rules;

public static class InputValidation
{
    public static bool ValidateInterger(string input)
    {
        return int.TryParse(input, out int number);
    }

    public static bool ValidateString(string? input)
    {
        return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
    }

    public static bool ValidateExit(string input)
    {
        return input == "eof"
            || input == "EoF"
            || input == "EOF"
            || input == "Eof"
            || input == "eOf"
            || input == "eoF"
            || input == "eOF"
            || input == "EOf";
    }

    public static bool ValidateCandidateNameRepetition(List<Candidate> candidates, string input)
    {
        return candidates.Any(e => e.Name == input);
    }

    public static bool ValidateVotesCountRepetition(List<Candidate> candidates, int input)
    {
        return candidates.Any(e => e.VoteQuantity == input);
    }
}
