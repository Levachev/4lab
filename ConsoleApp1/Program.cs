using Everyone2Hackathon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Db;
using Microsoft.EntityFrameworkCore;

class Application  {
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Sandbox>();
                services.AddTransient<ITeamBuildingStrategy, OnlyJuniorWishTeamBuildingStrategy>();
                services.AddTransient<Hackathon>();
                services.AddTransient<HrManager>();
                services.AddTransient<HrDirector>(_ => new HrDirector(20 , 20));
                services.AddDbContextFactory<Context>(options => options.UseSqlite($"Data Source=hackathon.db"));
                services.AddScoped<IRepo, Repo>();
            });
    }
}