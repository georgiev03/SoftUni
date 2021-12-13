using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO.Inputs
{
    public class CarInputDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<int> PartsId { get; set; } = new List<int>();
    }
}
