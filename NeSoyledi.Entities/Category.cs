using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Category: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySlug { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Versus> Versus { get; set; }
        public ICollection<Discourse> Discourses { get; set; }

    }
}
