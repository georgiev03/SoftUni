using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDto
{
    [XmlType("customer")]
    public class ExportBuyerInfoDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bought-cars")]
        public string BoughtCarsCount { get; set; }

        [XmlAttribute("spent-money")]
        public decimal MoneySpent { get; set; }
    }
}
