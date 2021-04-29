using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSoyledi.Entities
{
    public class Option : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public bool IsActive { get; set; }
    }
}
