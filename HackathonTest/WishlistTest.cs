using NUnit.Framework;
using Everyone2Hackathon;

namespace HackathonTest;

public class WishlistTests
{
    [Test]
    public void TestCorrectListSize()
    {
        var teammates = new List<Developer>();
        for (int i = 0; i < 10; i++)
        {
            teammates.Add(new Developer(i, "", Jobs.Junior));
        }
        
        var developer = new Developer(11, "11", Jobs.Junior);
        var wishlist = developer.FormWishlist(teammates);

        Assert.That(wishlist.Length, Is.EqualTo(teammates.Count));
    }
    
    [Test]
    public void TestDeveloperExists()
    {
        var teammates = new List<Developer>();
        for (int i = 0; i < 10; i++)
        {
            teammates.Add(new Developer(i, "", Jobs.Junior));
        }
        
        var intern = new Developer(11, "11", Jobs.Junior);
        teammates.Add(intern);
        
        var developer = new Developer(11, "11", Jobs.Junior);
        var wishlist = developer.FormWishlist(teammates);

        Assert.True(wishlist.Contains(intern));
    }
}