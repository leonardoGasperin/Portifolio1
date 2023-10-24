using Apresentation;
using Infrastructure.Service;

ElectionSystem electionSystem = new(
    new ProcessBallotService(),
    new RegistryCandidateService(),
    new()
);

electionSystem.Start();
