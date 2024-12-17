namespace Everyone2Hackathon;

public class HrDirector
{
    private int _juniorsCount;
    private int _teamleadsCount;

    public HrDirector(int juniorsCount, int teamleadsCount)
    {
        _juniorsCount = juniorsCount;
        _teamleadsCount = teamleadsCount;
    }

    public double CalculateHarmony(List<Wishlist> wishlists, List<Team> teams)
    {
        var harmonyIndexes = new int[wishlists.Count];

        for (int i = 0; i < teams.Count; i++)
        {
            Team team = teams[i];
            harmonyIndexes[i * 2] = GetHarmonyIndex(team.Junior, team.Teamlead, _teamleadsCount, wishlists);
            harmonyIndexes[i * 2 + 1] = GetHarmonyIndex(team.Teamlead, team.Junior, _juniorsCount, wishlists);
        }

        return Helper.HarmonicMean(harmonyIndexes);
    }

    private int GetHarmonyIndex(Developer dev, Developer teammate, int teammatesCount, List<Wishlist> wishlists)
    {
        Wishlist? wishlist = wishlists.Find(w => w.Owner.Id == dev.Id);
        int teammateIndex = Array.IndexOf(wishlist.Priorities, teammate);
        return teammatesCount - teammateIndex;
    }
}
