namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
