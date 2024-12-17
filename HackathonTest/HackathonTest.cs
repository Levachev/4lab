using Everyone2Hackathon;
using Moq;
using NUnit.Framework;

namespace HackathonTest;

public class HackathonTest
{
    private Mock<Hackathon> _hackathonMock = new Mock<Hackathon>();

    [Test]
    public void TestCorrectHarmonyResult()
    {
        var junior1 = new Developer(1, "", Jobs.Junior);
        var teamlead1 = new Developer(2, "", Jobs.Teamlead);
        
        var junior2 = new Developer(3, "", Jobs.Junior);
        var teamlead2 = new Developer(4, "", Jobs.Teamlead);
        
        var wishlist1 = new Wishlist(junior1, new[] { teamlead1, teamlead2 });
        var wishlist2 = new Wishlist(junior2, new[] { teamlead1, teamlead2 });
        
        var wishlist3 = new Wishlist(teamlead1, new[] { junior1, junior2 });
        var wishlist4 = new Wishlist(teamlead2, new[] { junior1, junior2 });
        var wishlists = new List<Wishlist> { wishlist1, wishlist2, wishlist3, wishlist4 };

        _hackathonMock.Setup(h => h.HoldEvent()).Returns(wishlists);
        
        //var sandbox = new Sandbox(new HrManager(new OnlyJuniorWishTeamBuildingStrategy()), new HrDirector(2, 2), _hackathonMock.Object);
    }
}