using System.ComponentModel.DataAnnotations;

namespace BlogMgmt.Models.ViewModels
{
    public class AddBlogModel

    {
        public int Id { get; set; }
       [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
         [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }


}