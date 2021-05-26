using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VegaITPraksa.Models;

namespace VegaITPraksa.DTO
{
    public class SimpleMappings : Profile
    {
        public SimpleMappings()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<TeamMember, TeamMemberDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();

        }
    }
}
