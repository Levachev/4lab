using Everyone2Hackathon;
using NUnit.Framework;

namespace HackathonTest;

public class HrDirectorTest
{
    [Test]
    public void TestCorrectSameNumbersHarmony()
    {
        var number = 2;
        var numbers = new int[] { number, number };
        Assert.That(Helper.HarmonicMean(numbers), Is.EqualTo(number));
    }
    
    [Test]
    public void TestCorrectDifferentNumbersHarmony()
    {
        var numbers = new int[] { 2, 6 };
        var expected = 3;
        Assert.That(Helper.HarmonicMean(numbers), Is.EqualTo(expected));
    }
    
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
        
        var team1 = new Team(junior1, teamlead1);
        var team2 = new Team(junior2, teamlead2);
        
        var wishlists = new List<Wishlist> { wishlist1, wishlist2, wishlist3, wishlist4 };
        var teams = new List<Team> { team1, team2 };

        var hrDirector = new HrDirector(2, 2);
        var actual = hrDirector.CalculateHarmony(wishlists, teams);
        var expected = 1.3333333333333333d;

        Assert.That(actual, Is.EqualTo(expected));
    }
}