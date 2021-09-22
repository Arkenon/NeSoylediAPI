using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities 
{
    public class News : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
       
        [MaxLength(255)]
        public string NewsImage { get; set; }

        [MaxLength(1500)]
        public string NewsVideo { get; set; }
        [MaxLength(4000)]
        public string NewsBefore { get; set; }
        [MaxLength(4000)]
        public string NewsAfter { get; set; }

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

    }
}
