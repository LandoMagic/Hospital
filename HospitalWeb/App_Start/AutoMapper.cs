using AutoMapper;
using HospitalModel;
using HospitalWeb.ViewModels;

namespace HospitalWeb
{
    public class AutoMapper
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            });
        }
    }
}