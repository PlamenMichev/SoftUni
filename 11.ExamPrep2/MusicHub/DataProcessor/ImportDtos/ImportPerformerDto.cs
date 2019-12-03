using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Range(18, 70)]
        public int Age { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportSongIdDto[] PerformerSongs { get; set; }
    }
}
