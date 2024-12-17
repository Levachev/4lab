using NUnit.Framework;
using Everyone2Hackathon;
using Moq;

namespace HackathonTest;

public class HrManagerTest
{
    private Mock<ITeamBuildingStrategy> _strategyMock = new Mock<ITeamBuildingStrategy>();

    [Test]
    public void TestCorrectTeamlistSize()
    {
        var juniors = new List<Developer>();
        var teamleads = new List<Developer>();
        for (int i = 0; i < 10; i++)
        {
            juniors.Add(new Developer(i, "", Jobs.Junior));
            teamleads.Add(new Developer(i, "", Jobs.Teamlead));
        }

        var hackathon = new Hackathon();
        hackathon.SetJuniors(juniors);
        hackathon.SetTeamleads(teamleads);

        var wishlists = hackathon.HoldEvent();

        var result = new HrManager(new OnlyJuniorWishTeamBuildingStrategy()).BuildTeams(wishlists);
        
        Assert.That(result.Count * 2, Is.EqualTo(wishlists.Count));
    }
    
    [Test]
    public void TestCorrectStrategyResult()
    {
        var junior = new Developer(1, "", Jobs.Junior);
        var teamlead = new Developer(2, "", Jobs.Teamlead);
        
        var wishlists = new List<Wishlist>() { new Wishlist(junior, new []{teamlead}), new Wishlist( teamlead, new [] {junior}) };

        var result = new HrManager(new OnlyJuniorWishTeamBuildingStrategy()).BuildTeams(wishlists);
        
        Assert.That(result[0], Is.EqualTo(new Team(junior, teamlead)));
    }
    
    [Test]
    public void TestStrategyInvokedOnce()
    {
        var junior = new Developer(1, "", Jobs.Junior);
        var teamlead = new Developer(2, "", Jobs.Teamlead);
        
        var wishlists = new List<Wishlist>() { new Wishlist(junior, new []{teamlead}), new Wishlist( teamlead, new [] {junior}) };
        _strategyMock.Setup(s => s.BuildTeams(wishlists)).Returns(new List<Team>());
        
        var result = new HrManager(_strategyMock.Object).BuildTeams(wishlists);
        
        _strategyMock.Verify(mock => mock.BuildTeams(wishlists), Times.Once());
    }
}