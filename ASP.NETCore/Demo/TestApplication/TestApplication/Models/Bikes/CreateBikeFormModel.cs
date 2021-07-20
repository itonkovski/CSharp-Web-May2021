using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestApplication.Data;

namespace TestApplication.Models.Bikes
{
    using static DataConstants.Bike;

    public class CreateBikeFormModel
    {
        [Required]
        [StringLength(
            BrandMaxLength,
            MinimumLength = BrandMinLength,
            ErrorMessage = "The field should contain from {2} to {1} symbols.")]
        public string Brand { get; set; }

        [Required]
        [StringLength(
            ModelMaxLength,
            MinimumLength = ModelMinLength,
            ErrorMessage = "The field should contain from {2} to {1} symbols.")]
        public string Model { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field should contain at least {2} symbols.")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        [Display(Name = "Category")]
        [Required]
        public string CategoryId { get; set; }

        public bool Agreements { get; set; }

        public IEnumerable<BikeCategoryViewModel> Categories { get; set; }
    }
}
