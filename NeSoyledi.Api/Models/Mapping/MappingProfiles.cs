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
            CreateMap<CategoryWithDiscourseDTO, Category>();
            CreateMap<Category, CategoryWithDiscourseDTO>();
            CreateMap<CategoryWithVersusDTO, Category>();
            CreateMap<Category, CategoryWithVersusDTO>();

            //Discourse
            CreateMap<DiscourseDTO, Discourse>();
            CreateMap<DiscourseWithCategoryDTO, Discourse>();
            CreateMap<Discourse, DiscourseDTO>();
            CreateMap<Discourse, DiscourseWithCategoryDTO>();
            CreateMap<Discourse, DiscourseWithProfileDTO>();
            CreateMap<DiscourseWithProfileDTO, Discourse>();

            //Profile
            CreateMap<ProfileForDiscourseDTO, Profiles>();
            CreateMap<Profiles, ProfileForDiscourseDTO>();

        }
    }
}
