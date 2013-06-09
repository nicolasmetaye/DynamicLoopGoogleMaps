using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicLoopGoogleMaps.Models.Models
{
    public class BookStoreModel
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Books")]
        public List<int> BooksIds  { get; set; }

        public List<BookListItemModel> Books { get; set; }

        public bool IsEditMode { get; set; }
    }
}
