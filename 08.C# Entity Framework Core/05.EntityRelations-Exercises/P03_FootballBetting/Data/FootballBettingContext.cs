namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public FootballBettingContext()
            : base()
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=FootballBetting;Trusted_Connection=true");
            }
        }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Team>(team =>
                {
                    team
                        .HasOne(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    team
                        .HasOne(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    team
                        .HasOne(t => t.Town)
                        .WithMany(tn => tn.Teams)
                        .HasForeignKey(t => t.TownId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Player>(player =>
                {
                    player
                        .HasOne(p => p.Team)
                        .WithMany(t => t.Players)
                        .HasForeignKey(p => p.TeamId)
                        .OnDelete(DeleteBehavior.Restrict);

                    player
                        .HasOne(p => p.Position)
                        .WithMany(pos => pos.Players)
                        .HasForeignKey(p => p.PositionId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Game>(game =>
                {
                    game
                        .HasOne(g => g.HomeTeam)
                        .WithMany(ht => ht.HomeGames)
                        .HasForeignKey(g => g.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict);

                    game
                        .HasOne(g => g.AwayTeam)
                        .WithMany(at => at.AwayGames)
                        .HasForeignKey(g => g.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Town>(town =>
                {
                    town
                        .HasOne(t => t.Country)
                        .WithMany(c => c.Towns)
                        .HasForeignKey(t => t.CountryId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<PlayerStatistic>(playerStatisctic =>
                {
                    playerStatisctic
                        .HasKey(ps => new { ps.PlayerId, ps.GameId });

                    playerStatisctic
                        .HasOne(ps => ps.Player)
                        .WithMany(p => p.PlayerStatistics)
                        .HasForeignKey(ps => ps.PlayerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    playerStatisctic
                        .HasOne(ps => ps.Game)
                        .WithMany(g => g.PlayerStatistics)
                        .HasForeignKey(ps => ps.GameId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Bet>(bet =>
                {
                    bet
                        .HasOne(b => b.Game)
                        .WithMany(g => g.Bets)
                        .HasForeignKey(b => b.GameId)
                        .OnDelete(DeleteBehavior.Restrict);

                    bet
                        .HasOne(b => b.User)
                        .WithMany(u => u.Bets)
                        .HasForeignKey(b => b.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
