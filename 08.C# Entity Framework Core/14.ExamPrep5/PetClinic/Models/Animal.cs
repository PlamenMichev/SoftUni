﻿namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
    }
}
