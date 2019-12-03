namespace MusicHub.DataProcessor.ImportDtos
{
    using MusicHub.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public string Duration { get; set; }

        public string CreatedOn { get; set; }

        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int WriterId { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
