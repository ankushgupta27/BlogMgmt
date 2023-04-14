using System.ComponentModel.DataAnnotations;

namespace BlogMgmt.Models.ViewModels
{
    public class AddBlogModel

    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }


}