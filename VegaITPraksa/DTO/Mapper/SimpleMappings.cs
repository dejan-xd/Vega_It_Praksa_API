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
            CreateMap<TeamMemberDTO, TeamMember>();
            CreateMap<TeamMember, TeamMemberDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<TeamMemberProjectDTO, TeamMemberProject>();
            CreateMap<TeamMemberProject, TeamMemberProjectDTO>();
        }
    }
}
