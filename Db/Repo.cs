using Everyone2Hackathon;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class Repo : IRepo
{
    private Context Context;
    private int currentHackathonId = 0;
    private int currentWishlistId = 0;
    private int currentTeamId = 0;

    public Repo(IDbContextFactory<Context> dbContextFactory)
    {
        Context = dbContextFactory.CreateDbContext();
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();
    }

    public void addDeveloper(List<Developer> developers)
    {
        Context.Set<Entities.DeveloperTable>().AddRange(developers.Select(m => new Entities.DeveloperTable()
        {
            Id = m.Id,
            Name = m.Name,
            Job = m.Job.ToString()
        }).ToList());
        Context.SaveChanges();
        Console.WriteLine("Added developers");
    }

    public int saveHackathon(double harmony, List<Wishlist> wishlist, List<Developer> members, List<Team> teams)
    {
        var membersTable = members.Select(m => Context.DeveloperTables.Where(d => d.Id == m.Id).ToList()[0]).ToList();
        var wishlistsTable = wishlist.Select(w => new Entities.WishlistTable()
        {
            OwnerId = w.Owner.Id,
            Priorities = PrioritiesConverter.ConvertPriorities(w.Priorities.Select(p => p.Id)),
        }).ToList();
        var teamsTable = teams.Select(t => new Entities.TeamTable()
        {
            JuniorId = t.Junior.Id, 
            TeamleadId = t.Teamlead.Id,
        }).ToList();
        var hackathonTable = new Entities.HackathonTable()
        {
            Harmony = harmony,
            Members = membersTable,
            Wishlist = wishlistsTable,
            Teams = teamsTable
        };
        
        Context.Set<Entities.WishlistTable>().AddRange(wishlistsTable);
        Context.Set<Entities.TeamTable>().AddRange(teamsTable);
        Context.Set<Entities.HackathonTable>().Add(hackathonTable);
        Context.SaveChanges();
        
        return hackathonTable.Id;
    }

    public Entities.HackathonReport getReportedHackathon(int hackathonId)
    {
        var hackathons = Context.HackathonTables.Where(h => h.Id == hackathonId).ToList();
        if (hackathons.Count == 0)
        {
            return null;
        }

        var hackathon = hackathons[0];
        return new Entities.HackathonReport()
        {
            Members = hackathon.Members.Select(m => new Developer(m.Id, m.Name, Enum.Parse<Jobs>(m.Job))).ToList(),
            Teams = hackathon.Teams.Select(t => new Team(
                findDeveloper(t.JuniorId),
                findDeveloper(t.TeamleadId)
                )).ToList(),
            Harmony = hackathon.Harmony,
        };
    }

    public double avgHarmony()
    {
        return Context.HackathonTables.Average(h => h.Harmony);
    }

    private Developer findDeveloper(int id)
    {
        Console.WriteLine("id - " + id);
        var tables = Context.DeveloperTables.Where(d => d.Id == id).ToList();
        if (tables.Count == 0)
        {
            return null;
        }
        var table = tables[0];
        return new Developer(table.Id, table.Name, Enum.Parse<Jobs>(table.Job));
    }

    private int getNextWishlistId()
    {
        return currentWishlistId++;
    }
    
    private int getNextTeamId()
    {
        return currentTeamId++;
    }
    
    private int getNextHackathonId()
    {
        return currentHackathonId++;
    }
}