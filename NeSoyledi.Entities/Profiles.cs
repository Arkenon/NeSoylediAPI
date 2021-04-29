using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Profiles : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string ProfileName { get; set; }

        [MaxLength(255)]
        public string ProfileTitle { get; set; }
        public string ProfileBio { get; set; }

        [MaxLength(255)]
        public string ProfileImage { get; set; }

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

        public ICollection<Discourse> Discourses { get; set; }
    }
}
