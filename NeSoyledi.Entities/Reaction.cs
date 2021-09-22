using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Reaction : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string PostType { get; set; }

        public int? UserId { get; set; }

        [MaxLength(255)]
        public string UserIP { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ReactionDate { get; set; }
    }
}
