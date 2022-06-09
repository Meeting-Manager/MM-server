using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager
{
    public class AutoMapping : Profile
    {
        
        public AutoMapping()
        {

        
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.CustomerName,
                            opts => opts.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.MeetingUserId,
                            opts => opts.MapFrom(src => src.MeetingUsers));

            CreateMap<User, UserLoginDTO>()
                .ReverseMap();

            CreateMap<Customer, CustomerLoginDTO>()
               .ReverseMap();

            CreateMap<MeetingUser, MeetingUserDTO>()
                .ForMember(dest => dest.MeetingUser,
                            opts => opts.MapFrom(src => src.User.Name)).ReverseMap();


            CreateMap<Meeting, MeetingDTO>()
                .AfterMap((m, md) =>
                { 
                    if (m.MeetingUsers.Count()!=0)
                    {
                          md.MeetingUsers=  m.MeetingUsers.Select(i =>
                                {
                                    if(i.User != null && i.User.Name != "")
                                        return i.User.Name;
                                    return "no name";
                                }).ToList();
                    }
            
                    
                   
                });

        }
    }
}