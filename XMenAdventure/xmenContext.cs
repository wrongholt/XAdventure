using System.Data.Entity;
using XMenAdventure.Models;

namespace XMenAdventure
{
    public class xmenContext : DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<equipment> equipments { get; set; }
        public DbSet<characterStats> stats { get; set; }
        public DbSet<equipmentList> equipmentLists { get; set; }
    }
}