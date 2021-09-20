using NeSoyledi.Entities;
using System;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int CommentPostId { get; set; }
        public string CommentPostType { get; set; }
        public string CommentContent { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CommentDate { get; set; }
        public User User { get; set; }
    }

    public class CommentByUserDTO
    {
        public int Id { get; set; }
        public int CommentPostId { get; set; }
        public string CommentPostType { get; set; }
        public string CommentPostSlug { get; set; }
        public string CommentPostTitle { get; set; }
        public string CommentContent { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
