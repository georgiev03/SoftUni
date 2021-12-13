using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.DTO.Inputs;
using CarDealer.DTO.Outputs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputDto, Supplier>();

            this.CreateMap<PartInputDto, Part>();

            this.CreateMap<CarInputDto, Car>();

            this.CreateMap<CustomerInputDto, Customer>();

            this.CreateMap<SaleInputDto, Sale>();

            this.CreateMap<Supplier, LocalSuppliersDto>()
                .ForMember(x => x.PartsCount,
                    y => y.MapFrom(src => src.Parts.Count));

                
        }
    }
}
