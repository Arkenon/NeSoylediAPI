using NeSoyledi.Entities;
using System.Collections.Generic;
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

    public class CategoryWithDiscourseDTO
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySlug { get; set; }
        public ICollection<DiscourseWithCategoryDTO> Discourses { get; set; }
    }

    public class CategoryWithVersusDTO
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySlug { get; set; }
        public ICollection<Versus> Versus { get; set; }
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
