﻿namespace ProductShop.Dtos.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
