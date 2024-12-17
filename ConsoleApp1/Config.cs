namespace Everyone2Hackathon;

internal record Config
{
    public int JuniorsCount { get; } = 20;
    
    public int TeamleadsCount { get; } = 20;

    public ITeamBuildingStrategy TeamBuildingStrategy { get; } = new OnlyJuniorWishTeamBuildingStrategy();
}
