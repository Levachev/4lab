namespace Everyone2Hackathon;

public class Hackathon
{
    private List<Developer> _juniors;
    private List<Developer> _teamleads;

    public Hackathon()
    {
    }

    public void SetJuniors(List<Developer> juniors)
    {
        _juniors = juniors;
    }

    public void SetTeamleads(List<Developer> teamleads)
    {
        _teamleads = teamleads;
    }

    public virtual List<Wishlist> HoldEvent()
    {
        var wishlists = new List<Wishlist>();

        foreach(var junior in _juniors)
        {
            Developer[] wishlist = junior.FormWishlist(_teamleads);
            wishlists.Add(new Wishlist(junior, wishlist));
        }

        foreach (var teamlead in _teamleads)
        {
            Developer[] wishlist = teamlead.FormWishlist(_juniors);
            wishlists.Add(new Wishlist(teamlead, wishlist));
        }

        return wishlists;
    }

    public List<Developer> GetMembers()
    {
        return _juniors.Concat(_teamleads).ToList();
    }
}
