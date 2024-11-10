using System;
using System.Collections.Generic;

namespace CNLTHD.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? Stock { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
