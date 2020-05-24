namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        [XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Card")]
        public string CardNumber { get; set; }
    }
}
