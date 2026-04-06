using System;
using System.Collections.Generic;

namespace practicaStartup.Domain.Database.SqlServe.Entities;

public partial class VGetAllCategory
{
    public string ParentProductCategoryName { get; set; } = null!;

    public string? ProductCategoryName { get; set; }

    public int? ProductCategoryId { get; set; }
}
