using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Everyone2Hackathon;

namespace Db;

public class Entities
{
    [Table("hackathon")]
    public class HackathonTable
    {
        [Key]
        public int Id { get; set; }
        public double Harmony { get; set; }

        public List<DeveloperTable> Members { get; set; }
        public List<WishlistTable> Wishlist { get; set; }
        public List<TeamTable> Teams { get; set; }
    }

    [Table("developer_table")]
    public class DeveloperTable
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Job { get; set; }
    }
    
    [Table("wishlist_table")]
    public class WishlistTable
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public String Priorities { get; set; }

        [ForeignKey("hackathon")]
        public int HackathonId { get; set; }
        public HackathonTable Hackathon { get; set; }
    }
    
    [Table("team_table")]
    public class TeamTable
    {
        [Key]
        public int Id { get; set; }
        public int JuniorId { get; set; }
        public int TeamleadId { get; set; }

        [ForeignKey("hackathon")]
        public int HackathonId { get; set; }
        public HackathonTable Hackathon { get; set; }
    }

    public class HackathonReport
    {
        public List<Developer> Members { get; set; }
        public List<Team> Teams { get; set; }
        public double Harmony { get; set; }

        public string getReport()
        {
            return "members - " + string.Join(", ", Members.Select(m => m.ToString())) + "\n" +
                            "teams - " + string.Join(", ", Teams.Select(t => t.ToString())) + "\n" +
                            "harmony - " + Harmony;
        }
    }
}