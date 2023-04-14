using System;
using System.Collections.Generic;

namespace BlogMgmt.Data.Entities;

public partial class Blog
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

    public virtual Category Category { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
