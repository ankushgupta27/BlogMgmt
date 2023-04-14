using System;
using System.Collections.Generic;

namespace BlogMgmt.Data.Entities;

public partial class State
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
