using System.Diagnostics.CodeAnalysis;

namespace Everyone2Hackathon;

public class Developer
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required Jobs Job { get; init; }

    public Developer() { }

    [SetsRequiredMembers]
    public Developer(int id, string name, Jobs job) 
    {
        Id = id;
        Name = name;
        Job = job;
    }

    public Developer[] FormWishlist(List<Developer> teammates)
    {
        Developer[] wishlist = teammates.ToArray();
        var rand = new Random();

        for (int i = 0; i < wishlist.Length - 1; i++)
        {
            int j = rand.Next(0, teammates.Count);

            (wishlist[j], wishlist[i]) = (wishlist[i], wishlist[j]);
        }

        return wishlist;
    }

    public override string ToString()
    {
        return $"{{{Id}, {Name}}}";
    }
}
