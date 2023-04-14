using System;
using System.Collections.Generic;

namespace BlogMgmt.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public long? MobileNo { get; set; }

    public bool IsActive { get; set; }

    public bool IsEmailVerified { get; set; }

    public int RoleId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual State? State { get; set; }
}
