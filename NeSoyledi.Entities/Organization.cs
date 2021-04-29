using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Organization : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string OrganizationName { get; set; }
        public string OrganizationHistory { get; set; }

        [MaxLength(255)]
        public string OrganizationLogo { get; set; }

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
