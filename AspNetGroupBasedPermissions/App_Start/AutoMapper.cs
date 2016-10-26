using AspNetGroupBasedPermissions.Model;
using AspNetGroupBasedPermissions.ViewModels;
using AutoMapper;

namespace AspNetGroupBasedPermissions
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