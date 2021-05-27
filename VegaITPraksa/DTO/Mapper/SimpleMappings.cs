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
            CreateMap<RoleDTO, Role>();
            CreateMap<TeamMemberDTO, TeamMember>();
            CreateMap<TeamMember, TeamMemberDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
