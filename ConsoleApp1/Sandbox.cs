using Microsoft.Extensions.Hosting;
using Db;

namespace Everyone2Hackathon;

public class Sandbox  : IHostedService
{
    private HrManager _hrManager;
    private HrDirector _hrDirector;
    private Hackathon _hackathon;
    private IRepo _repo;

    public Sandbox(HrManager hrManager, HrDirector hrDirector, Hackathon hackathon, IRepo repo)
    {
        var juniors = Helper.ReadDevsFromCsv("resourses/Juniors20.csv", Jobs.Junior);
        var teamleads = Helper.ReadDevsFromCsv("resourses/Teamleads20.csv", Jobs.Teamlead);
        _hrManager = hrManager;
        _hrDirector = hrDirector;
        _hackathon = hackathon;
        _hackathon.SetJuniors(juniors);
        _hackathon.SetTeamleads(teamleads);
        _repo = repo;
        
        _repo.addDeveloper(juniors.Concat(teamleads).ToList());
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var sumHarmony = 0.0;
        var hackathonsCount = 10;

        for (int i = 0; i < hackathonsCount; i++)
        {
            List<Wishlist> wishlists = _hackathon.HoldEvent();
            List<Team> teams = _hrManager.BuildTeams(wishlists);
            double harmony = _hrDirector.CalculateHarmony(wishlists, teams);
            sumHarmony += harmony;
            var id = _repo.saveHackathon(harmony, wishlists, _hackathon.GetMembers(), teams);
            Console.WriteLine("report :" + _repo.getReportedHackathon(id).getReport());
            Console.WriteLine($"Experiment {i + 1}: {harmony}");
        }
        Console.WriteLine("avg harmony :" + _repo.avgHarmony());

        double averageHarmony = sumHarmony / hackathonsCount;
        Console.WriteLine("harmony " + averageHarmony);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}