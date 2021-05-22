using System.ComponentModel.DataAnnotations;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySlug { get; set; }
    }

    public class SaveCategoryDTO
    {
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySlug { get; set; }
        public bool IsActive { get; set; }
    }

}
