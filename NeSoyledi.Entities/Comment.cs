using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Comment : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CommentPostId { get; set; }

        [MaxLength(1000)]
        public string CommentPostSlug { get; set; }

        [MaxLength(1000)]
        public string CommentPostTitle { get; set; }

        [MaxLength(255)]
        public string CommentPostType { get; set; }

        public string CommentContent { get; set; }
        public int? UserId { get; set; }

        [MaxLength(255)]
        public string UserIP { get; set; }

        [MaxLength(255)]
        public string UserName { get; set; }

        [MaxLength(255)]
        public string UserEmail { get; set; }        
        [MaxLength(255)]
        public string UserAgent { get; set; }
        public bool CommentStatus { get; set; }
        public int? CommentParent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
    }
}
