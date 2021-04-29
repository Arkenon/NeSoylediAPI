using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Discourse : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string DiscourseTitle { get; set; }
        public string DiscourseContent { get; set; }
        public int? ProfileId { get; set; }
        public int? UserId { get; set; }
        public int? OrganizationId { get; set; }
        public int CategoryId { get; set; }

        [MaxLength(255)]
        public string DiscourseImage { get; set; }

        [MaxLength(1500)]
        public string DiscourseVideo { get; set; }
        [MaxLength(4000)]
        public string DiscourseBefore { get; set; }
        [MaxLength(4000)]
        public string DiscourseAfter { get; set; }

        [MaxLength(255)]
        public string DiscourseSourceName { get; set; }

        [MaxLength(500)]
        public string DiscourseSourceUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DiscourseDate { get; set; }

        public bool CommentStatus { get; set; }

        [MaxLength(255)]
        public string PostType { get; set; }

        [MaxLength(255)]
        public string PostAuthor { get; set; }

        [MaxLength(255)]
        public string PostAuthorIP { get; set; }

        [MaxLength(1000)]
        public string PostSlug { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PostDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PostModifiedDate { get; set; }
        public int? PostReads { get; set; }
        public int? PostShares { get; set; }
        public bool IsActive { get; set; }

        public Profiles Profile { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
        public Category Category { get; set; }
    }
}
