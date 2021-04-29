using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class DiscourseDTO
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string DiscourseTitle { get; set; }
        public string DiscourseContent { get; set; }
     
        [MaxLength(255)]
        public string DiscourseImage { get; set; }

        [MaxLength(1500)]
        public string DiscourseVideo { get; set; }
        public string DiscourseBefore { get; set; }
        public string DiscourseAfter { get; set; }

        [MaxLength(100)]
        public string DiscourseSourceName { get; set; }

        [MaxLength(500)]
        public string DiscourseSourceUrl { get; set; }
        public DateTime DiscourseDate { get; set; }

        public bool CommentStatus { get; set; }

        [MaxLength(25)]
        public string PostType { get; set; }

        [MaxLength(60)]
        public string PostAuthor { get; set; }

        [MaxLength(1000)]
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

        [MaxLength(1000)]
        public string DiscourseTitle { get; set; }
        public string DiscourseContent { get; set; }

        [MaxLength(255)]
        public string DiscourseImage { get; set; }
        public DateTime DiscourseDate { get; set; }
        public Profiles Profile { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
    }
}
