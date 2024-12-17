namespace Everyone2Hackathon;

public class HrManager
{
    private readonly ITeamBuildingStrategy _teamBuildingStrategy;

    public HrManager(ITeamBuildingStrategy teamBuildingStrategy)
    {
        _teamBuildingStrategy = teamBuildingStrategy;
    }

    public List<Team> BuildTeams(List<Wishlist> wishlists)
    {
        if (wishlists.Count % 2 != 0)
        {
            throw new ArgumentException("Number of wishlists is odd, which means teams cannot be compiled");
        }
        return _teamBuildingStrategy.BuildTeams(wishlists);
    }
}
