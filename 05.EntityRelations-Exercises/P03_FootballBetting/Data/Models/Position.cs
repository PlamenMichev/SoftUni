namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
