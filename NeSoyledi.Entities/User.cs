using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string UserNameSurname { get; set; }

        [MaxLength(255)]
        public string UserLoginName { get; set; }

        [MaxLength(255)]
        public string UserNiceName { get; set; }

        [MaxLength(255)]
        public string UserEmail { get; set; }

        [MaxLength(255)]
        public string UserPass { get; set; }

        [MaxLength(100)]
        public string UserUrl { get; set; }

        [MaxLength(100)]
        public string UserAvatar { get; set; }

        [MaxLength(255)]
        public string UserGender { get; set; }

        [MaxLength(255)]
        public string UserBirthday { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UserRegistered { get; set; }

        [MaxLength(255)]
        public string UserActivationKey { get; set; }
        public bool UserStatus { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public ICollection<Discourse> Discourses { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
