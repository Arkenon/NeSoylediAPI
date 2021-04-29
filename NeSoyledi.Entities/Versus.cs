using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Versus : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string VersusTitle { get; set; }
        public string VersusContent { get; set; }
        public int DiscourseId1 { get; set; }
        public int DiscourseId2 { get; set; }
        public int CategoryId { get; set; }

        [MaxLength(255)]
        public string VersusImage { get; set; }

        [MaxLength(1500)]
        public string VersusVideo { get; set; }

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

        public Category Category { get; set; }
    }
}
