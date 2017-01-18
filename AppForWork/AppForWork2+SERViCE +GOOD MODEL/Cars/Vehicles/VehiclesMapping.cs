using System;
using System.Windows;
using AutoMapper;

namespace Cars.Vehicles
{
    public static class VehiclesMapping
    {
        static VehiclesMapping()
        {
            Mapper.Initialize(cfg=>
                              {
                                  cfg.CreateMap<ExtendedVehicle, Vehicle>()
                                      .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                                      .ForMember(x => x.Type, x => x.MapFrom(m => m.Type))
                                      .ForMember(x => x.VehiclePartsList, x => x.MapFrom(m => m.VehiclePartsList))
                                      .ForMember(x => x.AddOnsCollection, x => x.MapFrom(m => m.AddOnsCollection));

                                  cfg.CreateMap<Vehicle, ExtendedVehicle>()
                                        .ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
                                        .ForMember(x => x.Type, x => x.MapFrom(m => m.Type))
                                        .ForMember(x => x.VehiclePartsList, x => x.MapFrom(m => m.VehiclePartsList))
                                        .ForMember(x => x.AddOnsCollection, x => x.MapFrom(m => m.AddOnsCollection));
                              });
        }

        public static Vehicle ToVehicle(ExtendedVehicle extendedVehicle)
        {
            Vehicle vehicle = Mapper.Map<ExtendedVehicle,Vehicle>(extendedVehicle);

            return vehicle;
        }
        public static ExtendedVehicle ToExtendedVehicle(Vehicle vehicle)
        {
            ExtendedVehicle extendedVehicle = Mapper.Map<ExtendedVehicle>(vehicle);

            return extendedVehicle;
        }
    }
}