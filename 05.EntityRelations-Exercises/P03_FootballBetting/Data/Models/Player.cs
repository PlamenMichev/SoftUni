﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
