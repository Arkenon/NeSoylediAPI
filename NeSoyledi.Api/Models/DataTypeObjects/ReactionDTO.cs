using System;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class ReactionDTO
    {
        public int PostId { get; set; }

        public string PostType { get; set; }

        public int? UserId { get; set; }
        public string UserIP { get; set; }

        //1: Like, 2: Dislike, 3: Favorite
        public int ReactionType { get; set; }
        public DateTime ReactionDate { get; set; }
    }

    public class SaveReactionResponseDTO
    {
        public string ErrorMessage { get; set; }
        public bool Status { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TotalFavorites { get; set; }
    }
}
