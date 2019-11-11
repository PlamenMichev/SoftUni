namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}
