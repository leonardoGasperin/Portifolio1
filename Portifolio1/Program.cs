using Apresentation;
using Infrastructure.Service;

ElectionSystem electionSystem = new(
    new ProcessBallotService(),
    new RegistryCandidateService()
);

electionSystem.Start();
