using Microsoft.EntityFrameworkCore;
using TavolgaAPI.Models.Entityes;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models
{
    public class EfModel:DbContext
    {
        public EfModel(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContestantScore>().HasKey(cs => new { cs.CriteriaId, cs.AccessorId, cs.Contestant });
            modelBuilder.Entity<FinalScore>().HasKey(fs => new { fs.ContestantId, fs.CriteriaId });
        }
        public virtual DbSet<Accessor> Accessors { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<BaseUser> BaseUsers { get; set; }
        public virtual DbSet<Contestant> Contestants { get; set; }
        public virtual DbSet<Jury> Juries { get; set; }
        public virtual DbSet<ValuatorBase> Valuators { get; set; }
        public virtual DbSet<ContestantScore> ContestantScores { get; set; }
        public virtual DbSet<Criteria> Criteria { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<FinalScore> FinalScores { get; set; }
        public virtual DbSet<Nomination> Nominations { get; set; }
    }
}
