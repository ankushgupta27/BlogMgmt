using System.ComponentModel.DataAnnotations;

namespace BlogMgmt.Models.ViewModels
{
public partial class EditBlogModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

   
}
}