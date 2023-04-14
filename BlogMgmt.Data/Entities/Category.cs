using System;
using System.Collections.Generic;

namespace BlogMgmt.Data.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
}
