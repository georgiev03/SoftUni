using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Models;

namespace CarDealer.DTO.Outputs
{
    public class PartCarDto
    {
        public Car Car { get; set; }

        public Part Part { get; set; }
    }
}
