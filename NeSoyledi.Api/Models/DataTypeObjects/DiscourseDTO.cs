using NeSoyledi.Entities;
using System;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class DiscourseDTO
    {
        public int Id { get; set; }
        public string DiscourseTitle { get; set; }
        public string DiscourseContent { get; set; }
        public string DiscourseImage { get; set; }
        public string DiscourseVideo { get; set; }
        public string DiscourseBefore { get; set; }
        public string DiscourseAfter { get; set; }
        public string DiscourseSourceName { get; set; }
        public string DiscourseSourceUrl { get; set; }
        public DateTime DiscourseDate { get; set; }
        public bool CommentStatus { get; set; }
        public string PostType { get; set; }
        public string PostAuthor { get; set; }
        public string PostSlug { get; set; }
        public DateTime PostDate { get; set; }
        public int? PostReads { get; set; }
        public int? PostShares { get; set; }

        public ProfileForDiscourseDTO Profile { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class DiscourseWithCategoryDTO
    {
        public int Id { get; set; }
        public string DiscourseTitle { get; set; }
        public string DiscourseContent { get; set; }
        public string DiscourseImage { get; set; }
        public DateTime DiscourseDate { get; set; }
        public Profiles Profile { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
    }

    public class DiscourseWithProfileDTO
    {
        public int Id { get; set; }
        public string DiscourseTitle { get; set; }
        public string DiscourseImage { get; set; }
        public DateTime DiscourseDate { get; set; }
        public string PostSlug { get; set; }
    }
}
