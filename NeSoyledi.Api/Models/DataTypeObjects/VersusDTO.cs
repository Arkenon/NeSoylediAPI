using System;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class VersusDTO
    {
        public int Id { get; set; }
        public string VersusTitle { get; set; }
        public string VersusContent { get; set; }
        public int DiscourseId1 { get; set; }
        public int DiscourseId2 { get; set; }
        public string VersusImage { get; set; }
        public string VersusVideo { get; set; }
        public bool CommentStatus { get; set; }
        public string PostSlug { get; set; }
        public DateTime PostDate { get; set; }
        public int? PostReads { get; set; }
        public int? PostShares { get; set; }
        public bool IsActive { get; set; }

        public CategoryDTO Category { get; set; }
    }

    public class VersusForHomeDTO
    {
        public int Id { get; set; }
        public string VersusTitle { get; set; }
        public string VersusImage { get; set; }
        public string VersusContent { get; set; }
        public string PostSlug { get; set; }
        public DateTime PostDate { get; set; }
    }
}
