namespace Everyone2Hackathon;

public interface ITeamBuildingStrategy
{
    List<Team> BuildTeams(List<Wishlist> wishlists);
}
