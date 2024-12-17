using Everyone2Hackathon;

namespace Db;

public interface IRepo
{
    public int saveHackathon(double harmony, List<Wishlist> wishlist, List<Developer> members, List<Team> teams);
    public Entities.HackathonReport getReportedHackathon(int hackathonId);
    public double avgHarmony();
    public void addDeveloper(List<Developer> developers);
}