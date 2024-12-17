namespace Everyone2Hackathon;

public class OnlyJuniorWishTeamBuildingStrategy : ITeamBuildingStrategy
{
    public List<Team> BuildTeams(List<Wishlist> wishlists)
    {
        var chosenTeamleads = new HashSet<Developer>();
        var teams = new List<Team>();

        foreach (Wishlist wishlist in wishlists)
        {
            Developer owner = wishlist.Owner;
            if (owner.Job != Jobs.Junior)
            {
                continue;
            }

            var teamleadIndex = 0;
            Developer[] priorities = wishlist.Priorities;
            while (chosenTeamleads.Contains(priorities[teamleadIndex]))
            {
                teamleadIndex++;
            }

            Developer teamlead = priorities[teamleadIndex];
            chosenTeamleads.Add(teamlead);

            teams.Add(new Team(owner, teamlead));
        }

        return teams;
    }
}
