namespace Cinema.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        public int ProjectionId { get; set; }

        [Range(0.1, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}