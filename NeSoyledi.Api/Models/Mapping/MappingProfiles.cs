using AutoMapper;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Entities;


namespace NeSoyledi.Api.Models.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Category
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<SaveCategoryDTO, Category>();
            CreateMap<Category, SaveCategoryDTO>();

            //Discourse
            CreateMap<DiscourseDTO, Discourse>();
            CreateMap<DiscourseWithCategoryDTO, Discourse>();
            CreateMap<Discourse, DiscourseDTO>();
            CreateMap<Discourse, DiscourseWithCategoryDTO>();
            CreateMap<Discourse, DiscourseForProfileDTO>();
            CreateMap<DiscourseForProfileDTO, Discourse>();

            //Profile
            CreateMap<ProfileForDiscourseDTO, Profiles>();
            CreateMap<Profiles, ProfileForDiscourseDTO>();

            //User
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<UserTokenUpdateDTO, User>();
            CreateMap<User, UserTokenUpdateDTO>();
            CreateMap<SaveUserDTO, User>();
            CreateMap<User, SaveUserDTO>();
            CreateMap<UserDetailDTO, User>();
            CreateMap<User, UserDetailDTO>();

            //Versus
            CreateMap<VersusDTO, Versus>();
            CreateMap<Versus, VersusDTO>();
            CreateMap<VersusForHomeDTO, Versus>();
            CreateMap<Versus, VersusForHomeDTO>();
        }
    }
}
